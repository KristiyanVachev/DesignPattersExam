﻿using System;
using System.Collections.Generic;
using System.Net.Mail;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        private readonly IDatabase database;

        /* Could also extract Database provider for Teachers and Students collections
           But it will become too complex for the purposes of this exam */

        public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider, IDatabase database)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
            }

            if (parserProvider == null)
            {
                throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;
            this.database = database;

            this.parser.Database = database;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}

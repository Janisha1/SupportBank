using System;
using System.Globalization;
using SupportBank;

var parser = new CSVParser();
var ledger = parser.Parse();

ledger.PrintLedger();



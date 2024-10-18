namespace PP.Module.Common.Exceptions;

public class RecordNotFoundException(string commandName, string tableName, int id) : Exception($"{commandName}: Record {id} Not found {tableName}") { }

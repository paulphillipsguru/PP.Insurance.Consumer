namespace PP.Module.Common.Exceptions;
public class MissingSqlConnectionStringConfig(string name) : Exception($"Database Connection String {name} as not been configured") { }


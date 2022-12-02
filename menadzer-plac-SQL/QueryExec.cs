using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menadzer_plac_SQL
{
    class QueryExec
    {
        public object exec(String query, SQLiteConnection connection)
        {
            SQLiteCommand SQL = new SQLiteCommand(query);
            SQL.Connection = connection;
            return SQL.ExecuteScalar();
        }
    }
}

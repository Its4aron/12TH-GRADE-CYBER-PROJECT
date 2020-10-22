using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public class EntityChange
    {
        private BaseEntity entity;
        private CreateSql sql;

        public EntityChange(BaseEntity entity, CreateSql sql)
        {
            this.Entity = entity;
            this.sql = sql;
        }

        public BaseEntity Entity { get => entity; set => entity = value; }
        public CreateSql Sql { get => sql; set => sql = value; }
    }

    public delegate void CreateSql(BaseEntity entity,OleDbCommand cmd);
}

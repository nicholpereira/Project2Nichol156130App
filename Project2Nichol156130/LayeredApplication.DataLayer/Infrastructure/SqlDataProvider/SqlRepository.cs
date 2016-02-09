using LayeredApplication.DataLayer.Infrastructure.Repository;
using LayeredApplication.DataLayer.Infrastructure.Helper;
using LayeredApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LayeredApplication.DataLayer.Infrastructure.SqlDataProvider
{
    public class SqlRepository : IContext<Vehicle>
    {
        private string ConnectionString { get; set; }

        public SqlRepository(string conn)
        {
            this.ConnectionString = conn;
        }

        public Vehicle Add(Vehicle entity)
        {
            SqlHandler sqlHandler = new SqlHandler(this.ConnectionString);
            var parameters = entity.ToSqlParameters("Id");
            entity.Id = sqlHandler.Add("VehicleMaster", parameters);
            return entity;
        }

        public bool Update(Vehicle entity)
        {
            try
            {
                SqlHandler sqlHandler = new SqlHandler(this.ConnectionString);
                var parameters = entity.ToSqlParameters("Id");
                return sqlHandler.Update("VehicleMaster", parameters, entity.Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(Vehicle entity)
        {
            try
            {
                SqlHandler sqlHandler = new SqlHandler(this.ConnectionString);
                var parameters = entity.ToSqlParameters("Id");
                sqlHandler.Remove("VehicleMaster", parameters);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Vehicle Get(int id)
        {
            try
            {
                SqlHandler sqlHandler = new SqlHandler(this.ConnectionString);

                SqlParameter sqlp = new SqlParameter("@Id", id);

                var entities = sqlHandler.Get("VehicleMaster", sqlp).DataTableToList<Vehicle>();

                return entities.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Vehicle> Find(Func<Vehicle, bool> predicate)
        {
            try
            {
                return GetAll().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Vehicle> GetAll()
        {
            try
            {
                SqlHandler sqlHandler = new SqlHandler(this.ConnectionString);
                var entities = sqlHandler.Get("VehicleMaster")
                                         .DataTableToList<Vehicle>()
                                         .ToList();
                return entities;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
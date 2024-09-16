using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace task5.Models
{
    public class Repository
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        public void Register(Details r, string hobbiesString)
        {
            using (SqlCommand cmd = new SqlCommand("InsertTask", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", r.Name);
                cmd.Parameters.AddWithValue("@Mobile", r.Mobile);
                cmd.Parameters.AddWithValue("@Email", r.Email);
                cmd.Parameters.AddWithValue("@StateId", r.StateId);
                cmd.Parameters.AddWithValue("@CityId", r.CityId);
                cmd.Parameters.AddWithValue("@CreatedOn", r.CreatedOn);
                cmd.Parameters.AddWithValue("@Hobbies", hobbiesString); 

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /*  public void Register(Details r)
          {
              SqlCommand cmd = new SqlCommand("InsertTask", con);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@Name", r.Name);
              cmd.Parameters.AddWithValue("@Mobile", r.Mobile);
              cmd.Parameters.AddWithValue("@Email", r.Email);
              cmd.Parameters.AddWithValue("@StateId", r.StateId);
              cmd.Parameters.AddWithValue("@CityId", r.CityId);
              cmd.Parameters.AddWithValue("@CreatedOn", r.CreatedOn);
              // cmd.Parameters.AddWithValue("@Hobbies", r.Hobbies);
              var hobbiesString = string.Join(",", r.Hobbies);
              cmd.Parameters.AddWithValue("@Hobbies", hobbiesString);
            //  cmd.Parameters.AddWithValue("@Hobbies", string.Join(",", r.Hobbies));
              //cmd.Parameters.AddWithValue("@StateName", r.StateName);
              //cmd.Parameters.AddWithValue("@CityName", r.CityName);


              con.Open();
              cmd.ExecuteNonQuery();
              con.Close();
          }*/

        public List<Details> GetDetails1(string stat)
        {
            List<Details> obj = new List<Details>();

            SqlCommand cmd = new SqlCommand("PROC_CHECKBOX1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateName", stat);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Details
                {
                    Id = Convert.ToInt32(dr["TaskId"]),
                    Name = Convert.ToString(dr["Name"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),

                    CityName = Convert.ToString(dr["CityName"]),
                    StateName = Convert.ToString(dr["StateName"]),
                    CreatedOn = Convert.ToDateTime(dr["CretedOn"])


                }); ;
            }
            return obj;
        }
        public List<Details> GetDetails2(string city)
        {
            List<Details> obj = new List<Details>();

            SqlCommand cmd = new SqlCommand("PROC_CHECKBOX2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityName", city);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Details
                {
                    Id = Convert.ToInt32(dr["TaskId"]),
                    Name = Convert.ToString(dr["Name"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),

                    CityName = Convert.ToString(dr["CityName"]),
                    StateName = Convert.ToString(dr["StateName"]),
                    CreatedOn = Convert.ToDateTime(dr["CretedOn"])


                }); ;
            }
            return obj;
        }
        /*  public List<City> GetCitiesByState(string stateName)
          {
              List<City> cities = new List<City>();

              using (SqlCommand cmd = new SqlCommand("PROC_CHECKBOX5", con))
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@StateName", stateName);

                  SqlDataAdapter da = new SqlDataAdapter(cmd);
                  DataTable dt = new DataTable();
                  con.Open();
                  da.Fill(dt);
                  con.Close();

                  foreach (DataRow dr in dt.Rows)
                  {
                      cities.Add(new City
                      {
                          CityName = Convert.ToString(dr["CityName"])
                      });
                  }
              }

              return cities;
          }*/
        public List<string> GetCitiesByState(string stateName)
        {
            List<string> cities = new List<string>(); // Change to List<string>

            using (SqlCommand cmd = new SqlCommand("PROC_CHECKBOX5", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateName", stateName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    cities.Add(Convert.ToString(dr["CityName"])); // Add city names directly
                }
            }

            return cities; // Return List<string> directly
        }
        public List<Details> GetDetails3(string statename)
        {
            List<Details> obj = new List<Details>();

            SqlCommand cmd = new SqlCommand("PROC_CHECKBOX2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateName", statename);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Details
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),

                    CityName = Convert.ToString(dr["CityName"]),
                    StateName = Convert.ToString(dr["StateName"]),
                    CreatedOn = Convert.ToDateTime(dr["CretedOn"])


                }); ;
            }
            return obj;
        }
        public List<Details> GetDetails4(string statename)
        {
            List<Details> obj = new List<Details>();

            SqlCommand cmd = new SqlCommand("PROC_CHECKBOX2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateName", statename);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Details
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),

                    CityName = Convert.ToString(dr["CityName"]),
                    StateName = Convert.ToString(dr["StateName"]),
                    CreatedOn = Convert.ToDateTime(dr["CretedOn"])


                }); ;
            }
            return obj;
        }
        public List<Details> GetDetailsCities(string cityNames)
        {
            List<Details> obj = new List<Details>();

            SqlCommand cmd = new SqlCommand("GetDetailsByCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityNames", cityNames);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Details
                {
                    Id = Convert.ToInt32(dr["TaskId"]),
                    Name = Convert.ToString(dr["Name"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),

                    CityName = Convert.ToString(dr["CityName"]),
                    StateName = Convert.ToString(dr["StateName"]),
                    CreatedOn = Convert.ToDateTime(dr["CretedOn"])


                }); ;
            }
            return obj;
        }
        public List<State> GetStates()
        {
            List<State> states = new List<State>();

          
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM State";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            states.Add(new State
                            {
                                StateId = reader["StateId"] != DBNull.Value ? Convert.ToInt32(reader["StateId"]) : 0,
                                StateName = reader["StateName"].ToString()
                            });
                        }
                    }
                }
            } 

            return states;
        }


     
        public List<City> GetCities(int stateId)
        {
            List<City> cities = new List<City>();
            con.Open();
            string query = "SELECT * FROM City WHERE StateId = @StateId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StateId", stateId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cities.Add(new City
                {
                    CityId = Convert.ToInt32(reader["CityId"]),
                    CityName = reader["CityName"].ToString(),
                    StateId = Convert.ToInt32(reader["StateId"])
                });
            }
            con.Close();
            return cities;
        }
        public List<string> HobCheck(int id)
        {
            List<string> hobbies = new List<string>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proc_HobCheck", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string hobbiesString = reader["Hobbies"].ToString();
                                hobbies = hobbiesString.Split(',').ToList();
                            }
                        }

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ApplicationException("An error occurred while fetching hobbies.", ex);
            }

            return hobbies;
        }



        public List<Details> GetDetails()
        {
            List<Details> obj = new List<Details>();

            SqlCommand cmd = new SqlCommand("selecttask1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Details
                {
                    Id = Convert.ToInt32(dr["TaskId"]),
                    Name = Convert.ToString(dr["Name"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),
                    CityId = Convert.ToInt32(dr["CityId"]),

                    StateId = Convert.ToInt32(dr["StateId"]),
                    CityName = Convert.ToString(dr["CityName"]),
                    StateName = Convert.ToString(dr["StateName"]),
                    CreatedOn = Convert.ToDateTime(dr["CretedOn"])

                }); ;
            }
            return obj;
        }
        public List<Details> GetDetails(int id)
        {
            List<Details> obj = new List<Details>();

            SqlCommand cmd = new SqlCommand("selecttask2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(new Details
                {
                    Id = Convert.ToInt32(dr["TaskId"]),
                    Name = Convert.ToString(dr["Name"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Email = Convert.ToString(dr["Email"]),
                    CityId = Convert.ToInt32(dr["CityId"]),

                    StateId = Convert.ToInt32(dr["StateId"]),

                    CityName = Convert.ToString(dr["CityName"]),
                    StateName = Convert.ToString(dr["StateName"]),
                     

                }); ;
            }
            return obj;
        }
        public void Edit(int id,Details r)
        {
            using (var cmd = new SqlCommand("UpdateTask", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", r.Id);
                cmd.Parameters.AddWithValue("@Name", r.Name);
                cmd.Parameters.AddWithValue("@Mobile", r.Mobile);
                cmd.Parameters.AddWithValue("@Email", r.Email);
                cmd.Parameters.AddWithValue("@StateId", r.StateId);
                cmd.Parameters.AddWithValue("@CityId", r.CityId);
                cmd.Parameters.AddWithValue("@CreatedOn", r.CreatedOn);
                cmd.Parameters.AddWithValue("@Hobbies", string.Join(",", r.Hobbies)); 

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        

      /*  public void Edit(int id, Details r)
        {
            SqlCommand cmd = new SqlCommand("UpdateTask", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", r.Id);
            cmd.Parameters.AddWithValue("@Name", r.Name);

            cmd.Parameters.AddWithValue("@Mobile", r.Mobile);
            cmd.Parameters.AddWithValue("@Email", r.Email);
            cmd.Parameters.AddWithValue("@StateId", r.StateId);
            cmd.Parameters.AddWithValue("@CityId", r.CityId);
            cmd.Parameters.AddWithValue("@CreatedOn", r.CreatedOn);
            cmd.Parameters.AddWithValue("@Hobbies", r.Hobbies);
           
           

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }*/
         public void Delete(int id)
          {
              SqlCommand cmd = new SqlCommand("proc_delete", con);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@Id", id);
              con.Open();
              cmd.ExecuteNonQuery();
              con.Close();
          }
      /*  public bool Delete(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("proc_delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                  
                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                
                return false;
            }
        }*/

        public List<Details> GetPagedData(int pageSize, int pageNumber, string searchTerm, string cityNames, DateTime? startDate, DateTime? endDate, out int totalCount)
        {
            List<Details> obj1 = new List<Details>();

            using (SqlCommand cmd = new SqlCommand("PageTask", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageSize", pageSize);
                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);

                SqlParameter totalCountParam = new SqlParameter("@TotalCount", SqlDbType.Int);
                totalCountParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(totalCountParam);

                cmd.Parameters.AddWithValue("@SearchTerm", string.IsNullOrEmpty(searchTerm) ? (object)DBNull.Value : searchTerm);
                cmd.Parameters.AddWithValue("@CityNames", string.IsNullOrEmpty(cityNames) ? (object)DBNull.Value : cityNames);
                cmd.Parameters.AddWithValue("@StartDate", startDate.HasValue ? (object)startDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@EndDate", endDate.HasValue ? (object)endDate.Value : DBNull.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close(); 

                totalCount = (int)cmd.Parameters["@TotalCount"].Value;

                foreach (DataRow dr in dt.Rows)
                {
                    var hobbiesString = Convert.ToString(dr["Hobbies"]);

                    var hobbiesList = string.IsNullOrEmpty(hobbiesString) ? new List<string>() : hobbiesString.Split(',').ToList();

                    obj1.Add(new Details
                    {
                        Id = Convert.ToInt32(dr["TaskId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Mobile = Convert.ToString(dr["Mobile"]),
                        Email = Convert.ToString(dr["Email"]),
                        CityId = Convert.ToInt32(dr["CityId"]),
                        StateId = Convert.ToInt32(dr["StateId"]),
                        CityName = Convert.ToString(dr["CityName"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        CreatedOn = Convert.IsDBNull(dr["CreatedOn"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedOn"]),
                        Hobbies = hobbiesList
                    });
                }
            }

            return obj1;
        }

          public List<Details> GetPagedData1(int pageSize, int pageNumber,  out int totalCount)
           {
               List<Details> obj1 = new List<Details>();

               using (SqlCommand cmd = new SqlCommand("PageTask1", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@PageSize", pageSize);
                   cmd.Parameters.AddWithValue("@PageNumber", pageNumber);

                   SqlParameter totalCountParam = new SqlParameter("@TotalCount", SqlDbType.Int);
                   totalCountParam.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(totalCountParam);

              

                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                   DataTable dt = new DataTable();
                   con.Open();
                   da.Fill(dt);
                   totalCount = (int)cmd.Parameters["@TotalCount"].Value;

                   foreach (DataRow dr in dt.Rows)
                   {
                       obj1.Add(new Details
                       {
                           Id = Convert.ToInt32(dr["TaskId"]),
                           Name = Convert.ToString(dr["Name"]),
                           Mobile = Convert.ToString(dr["Mobile"]),
                           Email = Convert.ToString(dr["Email"]),
                           CityId = Convert.ToInt32(dr["CityId"]),
                           StateId = Convert.ToInt32(dr["StateId"]),
                           CityName = Convert.ToString(dr["CityName"]),
                           StateName = Convert.ToString(dr["StateName"]),

                          // CreatedOn = Convert.IsDBNull(dr["CreatedOn"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedOn"]) 
                       });
                   }
               }

               return obj1;
           }



    }

}



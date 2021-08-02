using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SearchTask.Models;
using System.Collections;

namespace SearchTask.DataAccessLayer
{
    public class DA
    {
        public List<City1> CitiesById(int StateId)
        {
            List<City1> ctlist = new List<City1>();
            SqlConnection con = new SqlConnection("user id=sa;password=sa123;database=countrystatecity;data source=upender;");
            SqlCommand cmd = new SqlCommand("select * from City where StateId=@StateId", con);
            cmd.Parameters.AddWithValue("StateId", @StateId);
            //SqlDataReader dr = cmd.ExecuteReader();
            // Method for citybind..!
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ctlist.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
            }


            //ctlist = da.Cities.Where(x=>x.StateId==id).ToList();

            return ctlist;
        }

        public List<State1> StatesById(int CountryId)
        {
            List<State1> slist = new List<State1>();
            SqlConnection con = new SqlConnection("user id=sa;password=sa123;database=countrystatecity;data source=upender;");
            SqlCommand cmd = new SqlCommand("select * from State where CountryId=@CountryId", con);
            cmd.Parameters.AddWithValue("CountryId", @CountryId);
            //SqlDataReader dr = cmd.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                slist.Add(new State1 { StateId = Convert.ToInt32(dr["StateId"]), StateName = dr["StateName"].ToString(), Cities = CitiesById(Convert.ToInt32(dr["StateId"])) });
            }

            // slist = da.States.Where(x => x.CountryId == id).ToList();


            return slist;


        }
        public List<Country1> GetCountries()
        {
            List<Country1> clist = new List<Country1>();
            SqlConnection con = new SqlConnection("user id=sa;password=sa123;database=countrystatecity;data source=upender;");
            SqlCommand cmd = new SqlCommand("select * from Country", con);
            //SqlDataReader dr = cmd.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                clist.Add(new Country1 { CountryId = Convert.ToInt32(dr["CountryId"]), CountryName = dr["CountryName"].ToString(), States = StatesById(Convert.ToInt32(dr["CountryId"])) });
            }

            return clist;

        }
        public List<City1> GetAllCities(DataSet ds, int id)
        {
            int prevcityid = 0;
            List<City1> lc = new List<City1>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr["StateId"]) == id && prevcityid != id)
                {
                    lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                    prevcityid = Convert.ToInt32(dr["CityId"]);
                }
                else
                {

                }
            }
            return lc;
        }


        //Method for getting all states list by country id..!
        public List<State1> GetStatesById(DataSet ds, int id)
        {
            List<State1> ls = new List<State1>();

            int prevstateid = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                if (Convert.ToInt32(dr["CountryId"]) == id && prevstateid != Convert.ToInt32(dr["StateId"]))
                {
                    ls.Add(new State1 { StateId = Convert.ToInt32(dr["StateId"]), StateName = dr["StateName"].ToString(), Cities = GetAllCities(ds, Convert.ToInt32(dr["StateId"])) });
                    prevstateid = Convert.ToInt32(dr["StateId"]);
                }
                else
                {

                }
            }
            return ls;
        }
        //Method to Getting All Countries Data

        public List<Country1> GetAllCountries()
        {
            DataSet ds = new DataSet();
            ds = GetAllData();
            List<Country1> lcn = new List<Country1>();
            List<State1> ls = new List<State1>();
            List<City1> lc = new List<City1>();

            int prevcountryid = 0;
            int prevstateid = 0;
            int prevcityid = 0;
            //ArrayList arstate = new ArrayList();
            //ArrayList arcities = new ArrayList();
            Country1[] c1;
            State1[] s1;
            City1[] ct1;


            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                if(prevcountryid==0 && prevstateid ==0)
                {
                    lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                }
               else if(prevstateid == Convert.ToInt32(dr["StateId"]))
                {
                    lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                    ls.Add(new State1 { StateId = Convert.ToInt32(dr["StateId"]), StateName = dr["StateName"].ToString(), Cities = lc });
                }
                else if(prevstateid != Convert.ToInt32(dr["StateId"]) && prevcountryid ==Convert.ToInt32(dr["CountryId"]))
                {

                }
                else
                {

                }



























                //if(prevcountryid==0 && prevstateid==0)
                //{
                //    lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                //    lcn.Add(new Country1 { CountryId = Convert.ToInt32(dr["CountryId"]), CountryName = dr["CountryName"].ToString(), States = ls });
                //    prevstateid = Convert.ToInt32(dr["StateId"]);
                //    prevcountryid = Convert.ToInt32(dr["CountryId"]);
                //}
                //else
                //{

                //}
                //if(prevcountryid != Convert.ToInt32(dr["CountryId"]))
                //{
                //    lcn.Add(new Country1 { CountryId = Convert.ToInt32(dr["CountryId"]), CountryName = dr["CountryName"].ToString(), States = ls });
                //    prevcountryid = Convert.ToInt32(dr["CountryId"]);
                //}
                //if (prevcountryid != Convert.ToInt32(dr["CountryId"]) && prevcountryid != 0)
                //{
                //    lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                //    prevstateid = Convert.ToInt32(dr["StateId"]);
                //    prevcountryid = Convert.ToInt32(dr["CountryId"]);
                //}

                //else
                //{
                //    if (Convert.ToInt32(dr["StateId"]) == prevstateid)
                //    {
                //        lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                //        ls.Add(new State1 { StateId = Convert.ToInt32(dr["StateId"]), StateName = dr["StateName"].ToString(), Cities = lc });
                //        lc.Clear();
                //    }

                //}

            }





            return lcn;
        }
        //Method for getting all data
       
        public DataSet GetAllData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            SqlCommand cmd = new SqlCommand("select c.CountryId ,c.CountryName,s.StateId ,s.StateName ,ct.CityId ,ct.CityName  from Country c inner join State s on c.CountryId=s.CountryId inner join City ct on ct.StateId=s.StateId", con);
            DataTable tbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public List<Country1> GetAllCountriesnew()
        {
            DataSet ds = new DataSet();
            ds = GetAllData();
            List<Country1> lcn = new List<Country1>();
            List<State1> ls = new List<State1>();
            List<City1> lc = new List<City1>();

            int prevcountryid = 0;
            int prevstateid = 0;
            int prevcityid = 0;
            //ArrayList arstate = new ArrayList();
            //ArrayList arcities = new ArrayList();
            Country1[] c1;
            State1[] s1;
            City1[] ct1;
            int countryid=0, stateid =0;
            string countryname="", statename ="";
            List<City1> Citieslist = new List<City1>();
            List<State1> Stateslist = new List<State1>();
            prevstateid = Convert.ToInt32(ds.Tables[0].Rows[0]["StateId"]);
            prevcountryid = Convert.ToInt32(ds.Tables[0].Rows[0]["CountryId"]);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                //ls.Add(new State1 { StateId = Convert.ToInt32(dr["StateId"]), StateName = dr["StateName"].ToString()});

                if (prevcountryid == Convert.ToInt32(dr["CountryId"]) && prevstateid == Convert.ToInt32(dr["StateId"]))
                {
                    countryid = Convert.ToInt32(dr["CountryId"]);
                    countryname = dr["CountryName"].ToString();
                    if (prevstateid == Convert.ToInt32(dr["StateId"]))
                    {
                        stateid = Convert.ToInt32(dr["StateId"]);
                        statename = dr["StateName"].ToString();
                    }
                    else
                    {

                    }
                }
                else if (prevcountryid == Convert.ToInt32(dr["CountryId"]) && prevstateid != Convert.ToInt32(dr["StateId"]))
                {
                    Citieslist = lc;
                    ls.Add(new State1 { StateId = stateid, StateName = statename, Cities = Citieslist });
                    stateid = Convert.ToInt32(dr["StateId"]);
                    statename = dr["StateName"].ToString();
                    lc.Clear();
                }
                else {
                    Citieslist = lc;
                    ls.Add(new State1 { StateId = stateid, StateName = statename, Cities = Citieslist });
                    Stateslist = ls;
                    lcn.Add(new Country1 { CountryId = countryid, CountryName = countryname, States = ls });
                    countryid = Convert.ToInt32(dr["CountryId"]);
                    countryname = dr["CountryName"].ToString();
                    stateid = Convert.ToInt32(dr["StateId"]);
                    statename = dr["StateName"].ToString();
                    lc.Clear();
                    ls.Clear();
                }
                lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
            }
            Citieslist = lc;
            ls.Add(new State1 { StateId = stateid, StateName = statename, Cities = Citieslist });
            Stateslist = ls;
            lcn.Add(new Country1 { CountryId = countryid, CountryName = countryname, States = ls });
            //My code ends

            //if (prevcountryid == 0 && prevstateid == 0)
            //    {
                    
            //    }
            //    else if (prevstateid == Convert.ToInt32(dr["StateId"]))
            //    {
            //        lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
            //        ls.Add(new State1 { StateId = Convert.ToInt32(dr["StateId"]), StateName = dr["StateName"].ToString(), Cities = lc });
            //    }
            //    else if (prevstateid != Convert.ToInt32(dr["StateId"]) && prevcountryid == Convert.ToInt32(dr["CountryId"]))
            //    {

            //    }
            //    else
            //    {

            //    }



























                //if(prevcountryid==0 && prevstateid==0)
                //{
                //    lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                //    lcn.Add(new Country1 { CountryId = Convert.ToInt32(dr["CountryId"]), CountryName = dr["CountryName"].ToString(), States = ls });
                //    prevstateid = Convert.ToInt32(dr["StateId"]);
                //    prevcountryid = Convert.ToInt32(dr["CountryId"]);
                //}
                //else
                //{

                //}
                //if(prevcountryid != Convert.ToInt32(dr["CountryId"]))
                //{
                //    lcn.Add(new Country1 { CountryId = Convert.ToInt32(dr["CountryId"]), CountryName = dr["CountryName"].ToString(), States = ls });
                //    prevcountryid = Convert.ToInt32(dr["CountryId"]);
                //}
                //if (prevcountryid != Convert.ToInt32(dr["CountryId"]) && prevcountryid != 0)
                //{
                //    lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                //    prevstateid = Convert.ToInt32(dr["StateId"]);
                //    prevcountryid = Convert.ToInt32(dr["CountryId"]);
                //}

                //else
                //{
                //    if (Convert.ToInt32(dr["StateId"]) == prevstateid)
                //    {
                //        lc.Add(new City1 { CityId = Convert.ToInt32(dr["CityId"]), CityName = dr["CityName"].ToString() });
                //        ls.Add(new State1 { StateId = Convert.ToInt32(dr["StateId"]), StateName = dr["StateName"].ToString(), Cities = lc });
                //        lc.Clear();
                //    }

                //}

          





            return lcn;
        }
        //Method for getting all data


    }
}
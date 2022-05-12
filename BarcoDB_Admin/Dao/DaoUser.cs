﻿using BarcoDB_Admin.Models.Db;
using System.Collections.Generic;
using System.Linq;

namespace BarcoDB_Admin.Dao
{
    public class DaoUser : DAO
    {
        //Jarne
        //here comes all the data from Person

        //copies the data from DAO
        public DaoUser() : base()
        {

        }

        protected static readonly DaoUser _instanceUser = new();

        public static DaoUser InstanceUser()
        {
            return _instanceUser;
        }

        // LISTS
        // Eakarach
        // Returns list of all user
        public void RemoveUser(Person person)
        {
            _context.Remove(person);
            _context.SaveChanges();
        }

        public void AddUser(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public void EditUser(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }

        public List<Person> GetAllUser()
        {
            return _context.People.ToList();
        }
    }
}

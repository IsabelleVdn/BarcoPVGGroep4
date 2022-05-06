﻿using BarcoDB_Admin.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcoDB_Admin.Models.Db;
using System.Windows;
using BarcoDB_Admin.Dao;

namespace BarcoDB_Admin.ViewModels.DataBase
{
    class ViewModelDBDevision : AbstractViewModelBase
    {
        DaoDivision _dao = new DaoDivision();
        

        

        public ViewModelDBDevision() : base()
        {
            Load();
        }
        public List<RqBarcoDivision> AllDivisions
        {
            get; set;
        }

        public RqBarcoDivision SelectedDivision
        {
            get; set;
        }

        private void Load()
        {
            AllDivisions = _dao.GetAllDivisions();
        }
        private void DeleteResourceFromDB()
        {
            if (SelectedDivision != null)
            {
                if (MessageBox.Show( "Are you sure you want to delete this division?", "Delete division", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dao.RemoveDivision(SelectedDivision);
                    Load();
                    OnpropertyChanged("AllDivisions");

                }
                else
                {
                    MessageBox.Show("This division has not been deleted");
                }
               

            }
            else
            {
                MessageBox.Show("No division selected");
            }

        }
    }
}

﻿using BarcoPVG.Models.Classes;
using BarcoPVG.Models.Db;
using BarcoPVG.Viewmodels;
using BarcoPVG.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BarcoPVG.ViewModels.Login
{
    //Eakarach
    public class ViewModelLogin : AbstractViewModelBase
    {
        private ICommand loginCommand, exitCommand;

        private string _username = "username";
        private string _password = "password";

        bool isClicked = false;

        public ViewModelLogin() 
        {
            //MainWindowCommand = new DelegateCommand(DisplayMainWindow);
        }

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new Command((param) => this.DisplayLogin(param));
                }
                return loginCommand;
            }
            set
            {
                loginCommand = value;
            }
        }

        public ICommand ExitCommand
        { 
            get 
            {
                if (exitCommand == null)
                {
                    exitCommand = new Command((param) => this.ExitCommandMethode());
                }
                return exitCommand; 
            }
        }

        //MouseDown event
        public string Username 
        {
            get => _username;
            set
            {
                if (!isClicked)
                {
                    isClicked = true;
                    _username.GetType().GetEvent("MouseDown");
                    _username = string.Empty;
                    OnpropertyChanged("Username");
                }
                else
                {
                    _username = value;
                    OnpropertyChanged("Username");
                }

            }
             
        }
        public string Password
        { 
            get => _password;
            set
            {
                _password = value;
                OnpropertyChanged("Password");
            }
            
        }

        
        private void ExitCommandMethode()
        {
            foreach (Window item in Application.Current.Windows)
            {
                item.Close();
            }
        }

        private void DisplayLogin(object param)
        {
            ObservableCollection<object> listParameter = (ObservableCollection<object>)param;
            List<Person> allUser = _dao.GetAllUser();
            Person loginPerson = null;

            foreach (Person person in allUser)
            {
                if (person.Voornaam == (string)listParameter[0] && person.Password == (string)listParameter[1])
                {
                    //MessageBox.Show("OK");
                    loginPerson = person;
                }
            }

            if (loginPerson != null)
            {
                _dao.LoginSucceedded(loginPerson);
                foreach (Window item in Application.Current.Windows)
                {
                    item.Hide();
                }
                DisplayMainWindow();
            }
            else
            {
                MessageBox.Show("User or/and Password is not correct");
            }
        }


        public void DisplayMainWindow()
        {         
            MainWindow mainw = new MainWindow();
            mainw.Show();
        }
    }
}

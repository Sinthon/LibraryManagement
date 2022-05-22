﻿using LibraryManagement.Presenters;
using LibraryManagement.Views.Layout;
using LibraryManagement.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Views.Main
{
    public partial class MainView : Form, IMainView
    {

        public MainView()
        {
            InitializeComponent();
            Load += delegate
            {
                SetUp?.Invoke(this, EventArgs.Empty);
            };
        }

        private void Event_ResizeEnd(object sender, EventArgs e)
        {
            if((sender as Form).WindowState == FormWindowState.Normal)
            {
                (sender as Form).WindowState = FormWindowState.Maximized;
            }
        }

        private static MainView instance;
        public static MainView GetInstance()
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new MainView();
            }
            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Maximized;
                }
            }
            return instance;
        }

        public void IitialComponent()
        {   
            this.Controls.Add(SideBarMenu.GetInstance());
            this.Controls.Add(this.menuStrip);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            libraryInforToolStripMenuItem.Click += delegate
            {
                ShowPreference?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler SetUp;
        public event EventHandler ShowPreference;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ADO_NET_Lesson1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ovsan\Рабочий стол\Uni\ADO\ADO_NET-Lesson1\ADO_NET-Lesson1\ADO-201.mdf"";Integrated Security=True";
    }
}

﻿using ADO_NET_Lesson1.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ADO_NET_Lesson1.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for ManagerCrudWindow.xaml
    /// </summary>
    public partial class ManagerCrudWindow : Window
    {
        public Manager? Manager { get; set; }
        private ObservableCollection<Entities.Department> OwnerDepartments;
        public ManagerCrudWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner is OrmWindow owner)
            {
                DataContext = Owner;
                OwnerDepartments = owner.departments;
            }
            else
            {
                MessageBox.Show("Owner is not OrmWindow");
                Close();
            }

            if (this.Manager is null)
            {
                Manager = new Entities.Manager();
            }
            else
            {
                Surname_TxtBx.Text = Manager.Surname;
                Secname_TxtBx.Text = Manager.Secname;
                Name_TxtBx.Text = Manager.Name;
                MainDep_CmbBx.SelectedItem =
                    OwnerDepartments
                    .Where(d => d.Id == this.Manager.IdMainDep)
                    .First();
                SecDep_CmbBx.SelectedItem =
                   OwnerDepartments
                   .Where(d => d.Id == this.Manager.IdSecDep)
                   .FirstOrDefault();
                Chief_CmbBx.SelectedItem = (Owner as OrmWindow)?
                    .managers.FirstOrDefault(m => m.Id == this.Manager.IdChief);
            }
            Id_TxtBx.Text = Manager.Id.ToString();
        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Manager is null)
                return;

            if(Name_TxtBx.Text.Equals(String.Empty))
            {
                MessageBox.Show("Необхідно ввести прізвище");
                Name_TxtBx.Focus();
                return;
            }

            if(MainDep_CmbBx.SelectedItem is null)
            {
                MessageBox.Show("Необхідно вибрати робочий відділ");
                MainDep_CmbBx.Focus();
                return;
            }

            this.Manager.Surname = Surname_TxtBx.Text;
            this.Manager.Name = Name_TxtBx.Text;
            this.Manager.Secname = Secname_TxtBx.Text;

            if (MainDep_CmbBx.SelectedItem is Entities.Department mainDep)
                this.Manager.IdMainDep = mainDep.Id;
            else
                MessageBox.Show("MainDepComboBox.SelectedItem CAST Error");

            if (SecDep_CmbBx.SelectedItem is null)
                this.Manager.IdSecDep = null;
            else if (SecDep_CmbBx.SelectedItem is Entities.Department secDep)
                this.Manager.IdSecDep = secDep.Id;
            else
                MessageBox.Show("SecDep_CmbBx.SelectedItem CAST Error");


            DialogResult = true;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void RemoveSecDep_Btn_Click(object sender, RoutedEventArgs e)
        {
            SecDep_CmbBx.SelectedItem = null;
        }

        private void RemoveChief_Btn_Click(object sender, RoutedEventArgs e)
        {
            Chief_CmbBx.SelectedItem = null;
        }
    }
}

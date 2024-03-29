﻿using ADO_NET_Lesson1.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
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
    /// Interaction logic for SaleCrudWindow.xaml
    /// </summary>
    public partial class SaleCrudWindow : Window
    {
        public Sale? Sale{ get; set; }
        private ObservableCollection<Manager> OwnerManagers;
        private ObservableCollection<Product> OwnerProducts;
        public SaleCrudWindow()
        {
            InitializeComponent();
            Sale = null!;
            OwnerManagers = null!;
            OwnerProducts = null!;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner is OrmWindow owner)
            {
                DataContext = Owner;
                OwnerManagers = owner.managers;
                OwnerProducts = owner.products;
            }
            else
            {
                MessageBox.Show("Owner is not OrmWindow");
                Close();
            }

            if (Sale is null)
            {
                Sale = new Sale();
                Delete_Btn.IsEnabled = false;
            }
            else
            {
                Product_CmbBx.SelectedItem =
                    OwnerProducts
                    .Where(d => d.Id == Sale.Product_Id)
                    .First();
                ManagerId_CmbBx.SelectedItem =
                    OwnerManagers
                    .Where(d => d.Id == Sale.Manager_Id)
                    .First();
                Delete_Btn.IsEnabled = true;
            }

            Id_TxtBx.Text = Sale.Id.ToString();
            SaleDate_TxtBx.Text = Sale.SaleDt.ToString();
            Quantity_TxtBx.Text = Sale.Quantity.ToString();
        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Sale is null)
                return;

            if(Quantity_TxtBx.Text.Equals(String.Empty))
            {
                MessageBox.Show("Необхідно ввести кількість");
                Quantity_TxtBx.Focus(); 
                return;
            }
            int cnt; 
            try 
            { 
                cnt = Convert.ToInt32(Quantity_TxtBx.Text); 
            }
            catch
            {
                MessageBox.Show("Кількість не розпізнана (очікується число)"); 
                Quantity_TxtBx.Focus();
                return;
            }

            if(Product_CmbBx.SelectedItem is null)
            {
                MessageBox.Show("Необхідно вибрати товар");
                Product_CmbBx.Focus();
                return;
            }

            if(ManagerId_CmbBx.SelectedItem is null)
            {
                MessageBox.Show("Необхідно вибрати продавця");
                Product_CmbBx.Focus();
                return;
            }

            Sale.Quantity = cnt;

            if (Product_CmbBx.SelectedItem is Product product)
                Sale.Product_Id = product.Id;
            else
                MessageBox.Show("Product_CmbBx.SelectedItem CAST Error");

            if (ManagerId_CmbBx.SelectedItem is Manager manager)
                Sale.Manager_Id = manager.Id;
            else
                MessageBox.Show("ManagerId_CmbBx.SelectedItem CAST Error");

            DialogResult = true;
        }
        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = MessageBox.Show("Впевнені, що хочете вилучити продаж?", "Вилучення", MessageBoxButton.OKCancel);
            if (dialogResult == MessageBoxResult.OK)
            {
                Sale.DeleteDt = DateTime.Now;
            }
            else
            {
                return;
            }

            DialogResult = true;
        }
        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

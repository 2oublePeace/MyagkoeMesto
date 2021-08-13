﻿using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BusinessLogics;
using System;
using System.Windows;
using Unity;

namespace MebelCustomerView
{
	/// <summary>
	/// Логика взаимодействия для CreateMaterialWindow.xaml
	/// </summary>
	public partial class CreateMaterialWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        MaterialLogic _logic;
        public int Id { set { id = value; } }
        private int? id;
		
        public CreateMaterialWindow(MaterialLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new MaterialBindingModel
                {
                    Id = id,
                    Name = tbName.Text,
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }
    }
}
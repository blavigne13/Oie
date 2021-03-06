﻿using Oie.Infrastructure;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Oie.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private Visibility testViewVisibilty;
        private Visibility useCase16ViewVisibilty;
        private Visibility useCase6ViewVisibilty;

        public MainWindowViewModel()
        {
            this.UseCase16ViewVisibility = Visibility.Collapsed;
            this.UseCase6ViewVisibility = Visibility.Collapsed;
            this.TestViewVisibility = Visibility.Collapsed;

            this.UseCase16Command = new DelegateCommand(() =>
            {
                this.UseCase16ViewVisibility = Visibility.Visible;
                this.UseCase6ViewVisibility = Visibility.Collapsed;
                this.TestViewVisibility = Visibility.Collapsed;
            });

            this.UseCase6Command = new DelegateCommand(() =>
            {
                this.UseCase6ViewVisibility = Visibility.Visible;
                this.UseCase16ViewVisibility = Visibility.Collapsed;
                this.TestViewVisibility = Visibility.Collapsed;
            });
        }

        public ICommand UseCase16Command { get; set; }

        public ICommand UseCase6Command { get; set; }

        public Visibility TestViewVisibility
        {
            get
            {
                return this.testViewVisibilty;
            }

            set
            {
                this.SetProperty(ref this.testViewVisibilty, value);
            }
        }

        public Visibility UseCase16ViewVisibility
        {
            get
            {
                return this.useCase16ViewVisibilty;
            }

            set
            {
                this.SetProperty(ref this.useCase16ViewVisibilty, value);
            }
        }

        public Visibility UseCase6ViewVisibility
        {
            get
            {
                return this.useCase6ViewVisibilty;
            }

            set
            {
                this.SetProperty(ref this.useCase6ViewVisibilty, value);
            }
        }
    }
}

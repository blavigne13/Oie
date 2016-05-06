using Oie.Infrastructure;
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
        private Visibility useCase1ViewVisibilty;
        private Visibility useCase2ViewVisibilty;

        public MainWindowViewModel()
        {
            this.UseCase1ViewVisibility = Visibility.Collapsed;
            this.UseCase2ViewVisibility = Visibility.Collapsed;
            this.UseCase1Command = new DelegateCommand(() =>
            {
                this.UseCase1ViewVisibility = Visibility.Visible;
                this.UseCase2ViewVisibility = Visibility.Collapsed;
                this.TestViewVisibility = Visibility.Collapsed;
            });

            this.UseCase2Command = new DelegateCommand(() =>
            {
                this.UseCase2ViewVisibility = Visibility.Visible;
                this.UseCase1ViewVisibility = Visibility.Collapsed;
                this.TestViewVisibility = Visibility.Collapsed;
            });
        }

        public ICommand UseCase1Command { get; set; }

        public ICommand UseCase2Command { get; set; }

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

        public Visibility UseCase1ViewVisibility
        {
            get
            {
                return this.useCase1ViewVisibilty;
            }

            set
            {
                this.SetProperty(ref this.useCase1ViewVisibilty, value);
            }
        }

        public Visibility UseCase2ViewVisibility
        {
            get
            {
                return this.useCase2ViewVisibilty;
            }

            set
            {
                this.SetProperty(ref this.useCase2ViewVisibilty, value);
            }
        }
    }
}

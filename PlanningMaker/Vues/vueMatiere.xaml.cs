﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlanningMaker.Modele;
using System.Collections.ObjectModel;

namespace PlanningMaker.Vues
{
    /// <summary>
    /// Logique d'interaction pour vueMatiere.xaml
    /// </summary>
    public partial class vueMatiere : UserControl
    {
        private Matiere matiere;
        private ICollection<Enseignant> enseignantsAssocies;

        public ICollection<Enseignant> EnseignantsAssocies
        {
            get
            {
                return enseignantsAssocies;
            }
        }

        public vueMatiere()
        {
            InitializeComponent();
            matiere = new Matiere();
            enseignantsAssocies = new ObservableCollection<Enseignant>();
            DataContext = matiere;
        }

        public void setEnseignantsContext(ICollection<Enseignant> enseignants){

            ObjectDataProvider odp = this.FindResource("ComboSource") as ObjectDataProvider;
            
            if(odp != null)
                odp.ObjectInstance = enseignants;
        }

        private void ChangementSelectionUnEnseignant(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChangementSelectionProf(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AjouterProf(object sender, RoutedEventArgs e)
        {

        }

        private void AjouterProfPossible(object sender, RoutedEventArgs e)
        {

        }
    }
}

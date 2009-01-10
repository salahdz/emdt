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

namespace PlanningMaker.Vues
{
    /// <summary>
    /// Logique d'interaction pour VueEnseignant.xaml
    /// </summary>
    public partial class VueEnseignement : UserControl
    {
        private Enseignement enseignement;

        public Enseignement Enseignement
        {
            get
            {
                return enseignement;
            }
        }

        public VueEnseignement()
        {
            InitializeComponent();
        }

        public void SetPlanningContext(Planning planning)
        {
            ObjectDataProvider odp_matiere = this.FindResource("ComboSource_Matieres") as ObjectDataProvider;

            if (odp_matiere != null)
                odp_matiere.ObjectInstance = planning.Matieres;
            else
                odp_matiere.ObjectInstance = null;

            ObjectDataProvider odp_horaires = this.FindResource("ComboSource_Horaires") as ObjectDataProvider;

            if (odp_horaires != null)
                odp_horaires.ObjectInstance = planning.Horaires;
            else
                odp_horaires.ObjectInstance = null;

            ObjectDataProvider odp_salles = this.FindResource("ComboSource_Salles") as ObjectDataProvider;

            if (odp_horaires != null)
                odp_salles.ObjectInstance = planning.Salles;
            else
                odp_salles.ObjectInstance = null;

        }

        public void ChangeEnseignement(Enseignement enseignement)
        {
            this.enseignement = enseignement;
            DataContext = enseignement;
            IsEnabled = true;

            ObjectDataProvider odp_enseignants = this.FindResource("ComboSource_Enseignants") as ObjectDataProvider;

            if (odp_enseignants != null && enseignement.Matiere != null)
                odp_enseignants.ObjectInstance = enseignement.Matiere.Enseignants;
            else
                odp_enseignants.ObjectInstance = null;

            Matiere.SelectedItem = enseignement.Matiere;
            Type.SelectedItem = enseignement.Type;
            Enseignant.SelectedItem = enseignement.Enseignant;
            Salle.SelectedItem = enseignement.Salle;
            Horaire1.SelectedItem = enseignement.Horaire1;
            Horaire2.SelectedItem = enseignement.Horaire2;
        }

        public void ClearView()
        {
            enseignement = null;
            DataContext = null;
            IsEnabled = false;

            ObjectDataProvider odp_enseignants = this.FindResource("ComboSource_Enseignants") as ObjectDataProvider;

            if (odp_enseignants != null)
                odp_enseignants.ObjectInstance = null;

            Matiere.SelectedItem = null;
            Type.SelectedItem = null;
            Groupe.Text = null;
            Enseignant.SelectedItem = null;
            Salle.SelectedItem = null;
            Horaire1.SelectedItem = null;
            Horaire2.SelectedItem = null;
        }

        private void ChangementSelectionEnseignant(object sender, SelectionChangedEventArgs e)
        {
            Enseignant enseignant = Enseignant.SelectedItem as Enseignant;
            if (enseignant != null && enseignement!=null)
            {
                enseignement.Enseignant = enseignant;
            }
        }

        private void ChangementSelectionSalle(object sender, SelectionChangedEventArgs e)
        {
            Salle salle = Salle.SelectedItem as Salle;
            if (salle != null && enseignement!=null)
            {
                enseignement.Salle = salle;
            }
        }

        private void ChangementSelectionMatiere(object sender, SelectionChangedEventArgs e)
        {
            Matiere matiere = Matiere.SelectedItem as Matiere;
            if (matiere != null)
            {
                if (enseignement != null)
                    enseignement.Matiere = matiere;

                ObjectDataProvider odp_enseignants = this.FindResource("ComboSource_Enseignants") as ObjectDataProvider;

                if (odp_enseignants != null)
                    odp_enseignants.ObjectInstance = matiere.Enseignants;

                Enseignant.SelectedItem = matiere.Enseignants.First();
            }
        }

        private void ChangementSelectionHoraire1(object sender, SelectionChangedEventArgs e)
        {
            Horaire horaire = Horaire1.SelectedItem as Horaire;
            if (horaire != null && enseignement != null)
            {
                if (horaire != enseignement.Horaire2)
                    enseignement.Horaire1 = horaire;
                else
                {
                    MessageBox.Show("Les horaires sont identiques", "PlanningMaker",
                        MessageBoxButton.OK, MessageBoxImage.Stop);
                    Horaire1.SelectedItem = enseignement.Horaire1;
                }
            }
        }

        private void ChangementSelectionHoraire2(object sender, SelectionChangedEventArgs e)
        {
            Horaire horaire = Horaire2.SelectedItem as Horaire;
            if (horaire != null && enseignement != null)
            {
                if (horaire != enseignement.Horaire1)
                    enseignement.Horaire2 = horaire;
                else
                {
                    MessageBox.Show("Les horaires sont identiques", "PlanningMaker",
                        MessageBoxButton.OK, MessageBoxImage.Stop);
                    Horaire2.SelectedItem = enseignement.Horaire2;
                }
            }
        }

        private void RemoveHoraire2(object sender, RoutedEventArgs e)
        {
            enseignement.Horaire2 = null;
            Horaire2.SelectedIndex = -1;
        }
    }
}

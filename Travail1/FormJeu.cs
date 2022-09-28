using Travail1.Controllers;
using Travail1.Controls;
using Travail1.Models;

namespace Travail1
{
    public partial class FormJeu : Form
    {
        private Controleur controleur;
        private AffichageJoueur[] affichageJoueurs;

        public FormJeu(string joueur1, string joueur2)
        {
            InitializeComponent();
            controleur = new Controleur(joueur1, joueur2);
            joueursUi.Joueurs = controleur.Joueurs;
            picPlancheJeu.Image = controleur.DessinerPlancheJeu();
            InitAffichageJoueurs();
            foreach (Joueur joueur in controleur.Joueurs)
            {
                joueur.ABouger += Joueur_ABouger;
            }
        }

        private void Joueur_ABouger(object? sender, int ID)
        {
            affichageJoueurs[ID].reload();
            //TODO add the update of the player ui so that the point and the player turn always stay up to date ***********
        }

        private void InitAffichageJoueurs()
        {
            affichageJoueurs = new AffichageJoueur[controleur.Joueurs.Length];
            for (int i = 0; i < controleur.Joueurs.Length; ++i)
            {
                affichageJoueurs[i] = new AffichageJoueur(controleur.Joueurs[i]);
            }
            picPlancheJeu.Controls.Add(affichageJoueurs[0]);
            for (int i = 1; i < affichageJoueurs.Length; ++i)
            {
                affichageJoueurs[i - 1].Controls.Add(affichageJoueurs[i]);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            controleur.avancerJoueurDe();
        }

        private void FormJeu_Load(object sender, EventArgs e)
        {

        }
    }
}


Mercadona
====================================================

⇢ Présentation :
<br> Mercadona est une application permettant à ses utilisateurs de consulter les produits et offres promotionnelles proposés par l'enseigne.
<br>

⇢ Technologies utilisées :
<br>▹ ASP.NET 6.0
<br>▹ PostgreSQL
<br>▹ pgAdmin 4
<br>

⇢ Packages NuGet utilisés :
<br>Projet MercadonaStudi :
<br>▹ Microsoft.AspNetCore.Identity.EntityFrameworkCore V6.0.10
<br>▹ Microsoft.EntityFrameworkCore.Tools V7.0.5
<br>▹ Microsoft.VisualStudio.Web.CodeGeneration.Design V6.0.13
<br>▹ Npgsql.EntityFrameworkCore.PostgreSQL V7.0.4
<br>▹ Npgsql.EntityFrameworkCore.PostgreSQL.Design V1.1.0
<br>

<br>Projet MercadonaStudi.Test :
<br>▹ Microsoft.EntityFrameworkCore V7.0.5
<br>▹ Microsoft.EntityFrameworkCore.Sqlite V7.0.5
<br>▹ Microsoft.NET.Test.Sdk V17.6.0
<br>▹ coverlet.collector V6.0.0
<br>▹ xunit V2.4.2
<br>▹ xunit.runner.visualstudio V2.4.5
<br>

⇢ Prérequis :
<br>▹ .NET 6.0 doit être installé au préalable sur votre machine.
<br> Lien de téléchargement : https://dotnet.microsoft.com/en-us/download
<br>▹ PostgreSQL doit également être installé.
<br> Liens de téléchargement : https://www.postgresql.org/download/
<br>

⇢ Installation :
<br>Backend :
<br>▹ Clonez ce repository ;
<br>▹ Le serveur doit fonctionner sur `localhost` avec le port par défaut `7000` ;
<br>

<br>Base de données :
<br>▹ Lancez l'applicatif pgAdmin 4 et créez une nouvelle base de données ;
<br>▹ Rendez-vous dans la Console du Gestionnaire de package ;
<br>▹ Exécutez `add-migration InitialMigration` pour créer la première migration ;
<br>▹ Exécutez `update-database` afin d'enregistrer les modèles créés dans la base de données ;
<br>

<br>!! Info !!
<br>
<br>Les identifiants de connexion du compte administrateur sont les suivants :
<br>▹ Email : admin@gmail.com
<br>▹ Mot de passe : Admin@123

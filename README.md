
~ Installation ~
Pour faire fonctionner le projet, il est nécessaire de copier le fichier .env.example en remplaçant les valeurs par défaut pour accéder à la base de données. 

Mercadona
====================================================

⇢ Présentation :
<br> Mercadona est une application permettant à ses utilisateurs de consulter les produits et offres promotionnelles proposés par l'enseigne.

⇢ Technologies utilisées :
<br>▹ ASP.NET 6.0
<br>▹ PostgreSQL
<br>▹ pgAdmin 4

⇢ Packages NuGet utilisés :
<br>▹ Microsoft.AspNetCore.Identity.EntityFrameworkCore V6.0.10
<br>▹ Microsoft.EntityFrameworkCore.Tools V7.0.5
<br>▹ Microsoft.VisualStudio.Web.CodeGeneration.Design V6.0.13
<br>▹ Npgsql.EntityFrameworkCore.PostgreSQL V7.0.4
<br>▹ Npgsql.EntityFrameworkCore.PostgreSQL.Design V1.1.0

⇢ Prérequis :
<br>▹ .NET 6.0 doit être installé au préalable sur votre machine.
<br> Lien de téléchargement : https://dotnet.microsoft.com/en-us/download
<br>▹ PostgreSQL doit également être installé.
<br> Liens de téléchargement : https://www.postgresql.org/download/
<br>

⇢ Installation :
<br>Backend :
<br>▹ Clonez ce repository ;
<br>▹ Copiez le fichier .env.example en remplaçant les valeurs par défaut pour accéder à la base de données ;
<br>▹ Le serveur doit fonctionner sur `localhost` avec le port par défaut `7000` ;
<br>

<br>Base de données :
<br>▹ Lancez l'applicatif pgAdmin 4 et créez une nouvelle base de données ;
<br>▹ Vérifiez que les informations contenues dans le fichier config.json sont correctes et correspondent à votre base de données ;
<br>▹ Rendez-vous dans la Console du Gestionnaire de package ;
<br>▹ Exécutez `add-migration InitialMigrationodel:create --attributes "username:string email:string password:string" --name User` pour créer la première migration ;
<br>▹ Exécutez `update-database` afin d'enregistrer les modèles créés dans la base de données ;
<br>


using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Isen.desrumaux.Library
{
    /// <summary>
    /// Interface permettant de gérer des noeuds d'un arbre
    /// </summary>
    /// <typeparam name="T">Type de données stockées dans le noeud</typeparam>
    public interface INode<T>
    {
        /// <summary>
        /// Données du noeud
        /// </summary>
        T Value { get; set; }
        
        /// <summary>
        /// Id du noeud
        /// </summary>
        Guid Id { get; }
        
        /// <summary>
        /// Lien vers le parent
        /// </summary>
        INode<T> parent { get; set; }
        
        /// <summary>
        /// Liste des enfants du noeud
        /// </summary>
        List<INode<T>> children { get; set; }
        
        /// <summary>
        /// Profondeur du noeud
        /// </summary>
        int Depth { get; }

        /// <summary>
        /// Permet d'ajouter un noeud dans la liste des enfants
        /// </summary>
        /// <param name="node">Noeud à définir comme enfant du noeud courant</param>
        void AddChildNode(INode<T> node);

        /// <summary>
        /// Permet d'ajouter plusieurs noeuds en même temps à la liste des enfants
        /// </summary>
        /// <param name="nodeList">Liste des noeuds à ajouter comme enfants</param>
        void AddNodes(IEnumerable<INode<T>> nodeList);

        /// <summary>
        /// Suppression d'un noeud par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du noeud à supprimer</param>
        void RemoveChildNode(Guid id);
        
        /// <summary>
        /// Suprression d'un noeud par recherche de l'objet
        /// </summary>
        /// <param name="node">Noeud à supprimer</param>
        void RemoveChildNode(INode<T> node);
        
        /// <summary>
        /// Trouve un noeud dans la liste des enfants
        /// </summary>
        /// <param name="id">Id du noeud à chercher</param>
        /// <returns>Noeud trouvé ou Null</returns>
        INode<T> FindTraversing(Guid id);
        
        /// <summary>
        /// Trouve un noeud dans la liste des enfants
        /// </summary>
        /// <param name="node">Objet à chercher</param>
        /// <returns>Noeud trouvé ou Null</returns>
        INode<T> FindTraversing(INode<T> node);

        /// <summary>
        /// Permet de sérialiser les données contenues dans le noeud (valeur + enfants)
        /// </summary>
        /// <returns>Objet json</returns>
        JObject SerializeJson();

        /// <summary>
        /// Permet de désérialiser les données provenant d'un json vers un arbre de noeud d'un type défini
        /// </summary>
        /// <param name="jsonObjectToken">Fichier json</param>
        void DeserializeJson(JToken jsonObjectToken);
    }
}
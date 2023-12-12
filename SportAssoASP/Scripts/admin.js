function ouvrirDocument(docPath) {
    var documentPath = docPath // Remplacez par l'ID du document que vous souhaitez ouvrir

    // Vérifiez que le chemin d'accès n'est pas vide avant d'essayer d'ouvrir
    if (documentPath !== "") {
        // Ouvrir le document dans une nouvelle fenêtre
        alert("Le chemin d'accès au document : " + documentPath);
        //window.open(documentPath, '_blank');
    } else {
        // Afficher un message d'erreur si le chemin d'accès est vide
        alert("Le chemin d'accès au document est vide.");
    }

    // Retourner false pour éviter que le formulaire ne soit soumis
    return false;
}
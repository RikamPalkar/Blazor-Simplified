function toggleNode(nodeId) {
    var node = document.querySelector(`[data-node="${nodeId}"]`);
    if (node) {
        node.style.display = node.style.display === "none" ? "block" : "none";
    }
}
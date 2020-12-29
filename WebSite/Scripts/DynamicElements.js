function CreateElements(htmlTag, attr, id, textContext, parent) {
    debugger;
    var Child = document.createElement(htmlTag);

    if (textContext)
        Child.innerText = textContext;
    if (attr) {
        for (var i = 0; i < attr.length; i++) {
            for (var key in attr[i]) {
                Child.setAttribute(key, attr[i][key]);
            }
        }
    }
    if (id)
        Child.setAttribute('id', id);
    if (parent)
        parent.appendChild(Child);
    return Child;
}
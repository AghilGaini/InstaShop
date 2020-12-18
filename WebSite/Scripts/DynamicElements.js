function CreateElements(htmlTag,className,id,textContext)
{
    var Html = document.createElement(htmlTag);
    if (textContext)
        Html.textContext = textContext;
    if (className)
        Html.setAttribute('class', className);
    if (id)
        Html.setAttribute('id', id);

    return Html;
}
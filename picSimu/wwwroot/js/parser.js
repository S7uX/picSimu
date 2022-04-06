export function parsePic(sourceCode) {
    const codeBlock = document.createElement('pre');
    Parser.init().then(() => {
        const parser = new Parser;
        Parser.Language.load("wasm/tree-sitter-pic.wasm").then(Pic => {
            parser.setLanguage(Pic);
            const tree = parser.parse(sourceCode);
            // console.log(tree);
            console.log(tree.rootNode);
            
            for (const row of tree.rootNode.children) {
                let rowLength = 0;
                if(row.type === "row"){
                    const rowSpan = document.createElement('span');
                    for (const rowElement of row.children) {
                        console.log(rowElement.startPosition.column - rowLength);
                        const whitespaceLength = rowElement.startPosition.column - rowLength;
                        rowSpan.insertAdjacentText("beforeend", " ".repeat(rowElement.startPosition.column - rowLength));
                        const elementHtml = `<span class="${rowElement.type}">${rowElement.text}<span/>`
                        rowSpan.insertAdjacentHTML("beforeend",elementHtml)
                        rowLength += whitespaceLength + rowElement.text.length
                    }
                    rowSpan.insertAdjacentText("beforeend", "\n");
                    codeBlock.appendChild(rowSpan);
                }
            }
            
            document.getElementById("code-block").appendChild(codeBlock);
        });
    });
}
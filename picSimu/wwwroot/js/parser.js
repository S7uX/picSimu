export async function parsePic(sourceCode) {
    console.log("parsePic invoked");

    const codeBlock = document.createElement('pre');

    await Parser.init();
    const parser = new Parser;
    const PicLang = await Parser.Language.load("wasm/tree-sitter-pic.wasm")
    parser.setLanguage(PicLang);

    const tree = parser.parse(sourceCode);
    console.log("syntax tree:");
    console.log(tree.rootNode);

    let instructionCount = 0;
    for (const row of tree.rootNode.children) {
        let rowLength = 0;
        if (row.type === "row") {
            const rowSpan = document.createElement('span');
            for (const rowElement of row.children) {
                if (rowElement.type === "instruction") {
                    rowSpan.id = "instruction-" + instructionCount;
                    instructionCount++;
                }
                // console.log(row.text)
                const whitespaceLength = rowElement.startPosition.column - rowLength;
                rowSpan.insertAdjacentText("beforeend", " ".repeat(rowElement.startPosition.column - rowLength));
                const elementHtml = `<span class="${rowElement.type}">${rowElement.text}<span/>`
                rowSpan.insertAdjacentHTML("beforeend", elementHtml)
                rowLength += whitespaceLength + rowElement.text.length
            }
            rowSpan.classList.add("code-line");
            rowSpan.insertAdjacentText("beforeend", "\n");
            codeBlock.appendChild(rowSpan);
        }
    }

    document.getElementById("code-block").replaceChildren(codeBlock);

    const firstInstruction = document.getElementById("instruction-0");
    if(firstInstruction !== null){
        firstInstruction.classList.add("code-line-highlight");
    }
}

export async function getInstructionCodes(sourceCode) {
    console.log("getInstructionCodes invoked");

    await Parser.init();
    const parser = new Parser;
    const PicLang = await Parser.Language.load("wasm/tree-sitter-pic.wasm");
    parser.setLanguage(PicLang);
    const tree = parser.parse(sourceCode);

    let returnString = ""; // comma separated instruction codes 
    for (const row of tree.rootNode.children) {
        if (row.type === "row") {
            for (const rowElement of row.children) {
                if (rowElement.type === "instruction") {
                    rowElement.children[1].text; // second element is instruction code
                    returnString += rowElement.children[1].text + ","
                }
            }
        }
    }
    console.log("parsed instruction codes " + returnString);

    return returnString.slice(0, -1); // remove last comma
}

export function highlightCodeLine(programCounter) {
    // remove previous highlighting
    document.getElementsByClassName("code-line-highlight")[0].classList.remove("code-line-highlight");
    // highlight new line
    document.getElementById("instruction-" + programCounter).classList.add("code-line-highlight");
}
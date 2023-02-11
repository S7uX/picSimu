const parserIframe = document.createElement("iframe")
parserIframe.setAttribute("src", "parser-ifrmae.html")
parserIframe.setAttribute("hidden", "hidden")
document.body.appendChild(parserIframe)

async function createTree(sourceCode) {
    const Parser = parserIframe.contentWindow.TreeSitter
    await Parser.init();
    const parser = new Parser;
    const PicLang = await Parser.Language.load("wasm/tree-sitter-pic.wasm")
    parser.setLanguage(PicLang);

    const tree = parser.parse(sourceCode);
    console.log("syntax tree:");
    console.log(tree.rootNode);
    return tree;
}


async function parsePic(tree) {
    console.log("parsePic invoked");
    const codeBlock = document.getElementById("code-pre");
    codeBlock.innerHTML = "";

    for (const row of tree.rootNode.children) {
        let rowLength = 0;
        if (row.type === "row") {
            const rowSpan = document.createElement('span');
            for (const rowElement of row.children) {
                const whitespaceLength = rowElement.startPosition.column - rowLength;
                rowSpan.insertAdjacentText("beforeend", " ".repeat(rowElement.startPosition.column - rowLength));
                let text;
                if (rowElement.type === "instruction") {
                    const pcString = rowElement.children[0].text;
                    const pc = parseInt(pcString, 16);
                    rowSpan.id = `instruction-${pc}`
                    const opcodeString = rowElement.children[1].text;
                    const opcode = parseInt(opcodeString, 16);
                    text = `<span title="${pc}d\n${pc.toString(2).padStart(4, '0')}b">${pcString}</span>` +
                        ` <span title="${opcode.toString(2).padStart(14, '0')}b">${opcodeString}</span>`;
                } else {
                    text = rowElement.text;
                }
                rowSpan.insertAdjacentHTML("beforeend",
                    `<span class="${rowElement.type}">${text}<span/>`)
                rowLength += whitespaceLength + rowElement.text.length
            }
            rowSpan.classList.add("code-line");
            rowSpan.insertAdjacentText("beforeend", "\n");
            codeBlock.appendChild(rowSpan);
        }
    }

    const firstInstructionRow = document.getElementById("instruction-0");
    if (firstInstructionRow !== null) {
        firstInstructionRow.classList.add("code-line-highlight");
    }
}


async function getInstructionCodes(tree) {
    console.log("getInstructionCodes invoked");

    let returnVal = [];
    let i = 0;
    let rowNumber = 0;
    for (const row of tree.rootNode.children) {
        if (row.type === "row") {
            for (const rowElement of row.children) {
                if (rowElement.type === "instruction") {
                    const programCounter = rowElement.children[0].text; // first element is pc
                    const opcode = rowElement.children[1].text; // second element is instruction code
                    returnVal[i] = {
                        Opcode: parseInt(opcode, 16),
                        ProgramCounter: parseInt(programCounter, 16),
                        RowNumber: rowNumber
                    };
                    i++;
                }
            }
        }
        rowNumber++;
    }
    return returnVal;
}


export function highlightCodeLine(programCounter) {
    // remove previous highlighting
    const old = document.getElementsByClassName("code-line-highlight")[0];
    if (old !== undefined) {
        old.classList.remove("code-line-highlight");
    }
    // highlight new line
    const toHighlight = document.getElementById("instruction-" + programCounter);
    if (toHighlight !== null) {
        document.getElementById("instruction-" + programCounter).classList.add("code-line-highlight");
    } else {
        console.error("function highlightCodeLine: Given programCounter not found!")
    }
}


let DotNetObjRef;

export function setDotNetObjRef(dotNetObjRef) {
    DotNetObjRef = dotNetObjRef;
}

async function handleFile(file) {
    console.log(file);
    const sourceCode = await file.text();
    const tree = await createTree(sourceCode);
    const rowCount = tree.rootNode.children.length;
    parsePic(tree);
    const instructionCodes = await getInstructionCodes(tree);
    DotNetObjRef.invokeMethodAsync("LoadProgram", {
        RowCount: rowCount,
        InstructionCodes: instructionCodes
    });
}

document.getElementById("lst-file-input").addEventListener('change', e => {
    console.log(e);
    if(e.target.files[0] !== undefined){
        console.log("LOADING NEW LST FILE:");
        handleFile(e.target.files[0]);
    }
});
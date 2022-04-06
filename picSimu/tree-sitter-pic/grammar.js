module.exports = grammar({
    name: 'pic',

    rules: {
        // TODO: add the actual grammar rules
        source_file: $ => repeat($.row),

        row: $ => seq(
            optional($.instruction),
            $.row_number,
            repeat(choice($.mnemonic, $.other)),
            optional($.comment),
            /\n/
        ),

        instruction: $ => seq(
            $.instruction_number,
            $.instruction_code
        ),
        
        instruction_number: $ => /\d{4}/,
        
        instruction_code: $ => /[0-9a-fA-F]{4}/,

        row_number: $ => /\d{5}/,
        
        mnemonic: $ => choice(
            cI("ADDWF"),
            cI("ANDWF"),
            cI("CLRF"),
            cI("CLRW"),
            cI("COMF"),
            cI("DECF"),
            cI("DECFSZ"),
            cI("INCF"),
            cI("INCFSZ"),
            cI("IORWF"),
            cI("MOVF"),
            cI("MOVWF"),
            cI("NOP"),
            cI("RLF"),
            cI("RRF"),
            cI("SUBWF"),
            cI("SWAPF"),
            cI("XORWF"),
            cI("BCF"),
            cI("BSF"),
            cI("BTFSC"),
            cI("BTFSS"),
            cI("ADDLW"),
            cI("ANDLW"),
            cI("CALL"),
            cI("CLRWDT"),
            cI("GOTO"),
            cI("IORLW"),
            cI("MOVLW"),
            cI("RETFIE"),
            cI("RETLW"),
            cI("RETURN"),
            cI("SLEEP"),
            cI("SUBLW"),
            cI("XORLW")
        ),
        
        comment: $ => /;[^\n\r]*/,
        
        other: $ => /[^;\n\r ]+/
    }
});

function cI(keyword) {
    return new RegExp(keyword
        .split('')
        .map(letter => `[${letter}${letter.toLowerCase()}]`)
        .join('')
    )
}
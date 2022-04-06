function cI(keyword) {
    return new RegExp(keyword
        .split('')
        .map(letter => `[${letter}${letter.toUpperCase()}]`)
        .join('')
    )
}

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
    // cI("ANDLW"),
    /[An][Nn][Dd][Lw][Ww]/,
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
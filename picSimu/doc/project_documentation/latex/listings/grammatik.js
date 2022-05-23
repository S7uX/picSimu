rules: {
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
    instruction_number: $ => /[0-9a-fA-F]{4}/,
    // ...
}
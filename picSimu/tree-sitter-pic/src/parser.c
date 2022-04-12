#include <tree_sitter/parser.h>

#if defined(__GNUC__) || defined(__clang__)
#pragma GCC diagnostic push
#pragma GCC diagnostic ignored "-Wmissing-field-initializers"
#endif

#define LANGUAGE_VERSION 13
#define STATE_COUNT 23
#define LARGE_STATE_COUNT 8
#define SYMBOL_COUNT 49
#define ALIAS_COUNT 0
#define TOKEN_COUNT 41
#define EXTERNAL_TOKEN_COUNT 0
#define FIELD_COUNT 0
#define MAX_ALIAS_SEQUENCE_LENGTH 5
#define PRODUCTION_ID_COUNT 1

enum {
  aux_sym_row_token1 = 1,
  aux_sym_instruction_number_token1 = 2,
  sym_row_number = 3,
  aux_sym_mnemonic_token1 = 4,
  aux_sym_mnemonic_token2 = 5,
  aux_sym_mnemonic_token3 = 6,
  aux_sym_mnemonic_token4 = 7,
  aux_sym_mnemonic_token5 = 8,
  aux_sym_mnemonic_token6 = 9,
  aux_sym_mnemonic_token7 = 10,
  aux_sym_mnemonic_token8 = 11,
  aux_sym_mnemonic_token9 = 12,
  aux_sym_mnemonic_token10 = 13,
  aux_sym_mnemonic_token11 = 14,
  aux_sym_mnemonic_token12 = 15,
  aux_sym_mnemonic_token13 = 16,
  aux_sym_mnemonic_token14 = 17,
  aux_sym_mnemonic_token15 = 18,
  aux_sym_mnemonic_token16 = 19,
  aux_sym_mnemonic_token17 = 20,
  aux_sym_mnemonic_token18 = 21,
  aux_sym_mnemonic_token19 = 22,
  aux_sym_mnemonic_token20 = 23,
  aux_sym_mnemonic_token21 = 24,
  aux_sym_mnemonic_token22 = 25,
  aux_sym_mnemonic_token23 = 26,
  aux_sym_mnemonic_token24 = 27,
  aux_sym_mnemonic_token25 = 28,
  aux_sym_mnemonic_token26 = 29,
  aux_sym_mnemonic_token27 = 30,
  aux_sym_mnemonic_token28 = 31,
  aux_sym_mnemonic_token29 = 32,
  aux_sym_mnemonic_token30 = 33,
  aux_sym_mnemonic_token31 = 34,
  aux_sym_mnemonic_token32 = 35,
  aux_sym_mnemonic_token33 = 36,
  aux_sym_mnemonic_token34 = 37,
  aux_sym_mnemonic_token35 = 38,
  sym_comment = 39,
  sym_other = 40,
  sym_source_file = 41,
  sym_row = 42,
  sym_instruction = 43,
  sym_instruction_number = 44,
  sym_instruction_code = 45,
  sym_mnemonic = 46,
  aux_sym_source_file_repeat1 = 47,
  aux_sym_row_repeat1 = 48,
};

static const char * const ts_symbol_names[] = {
  [ts_builtin_sym_end] = "end",
  [aux_sym_row_token1] = "row_token1",
  [aux_sym_instruction_number_token1] = "instruction_number_token1",
  [sym_row_number] = "row_number",
  [aux_sym_mnemonic_token1] = "mnemonic_token1",
  [aux_sym_mnemonic_token2] = "mnemonic_token2",
  [aux_sym_mnemonic_token3] = "mnemonic_token3",
  [aux_sym_mnemonic_token4] = "mnemonic_token4",
  [aux_sym_mnemonic_token5] = "mnemonic_token5",
  [aux_sym_mnemonic_token6] = "mnemonic_token6",
  [aux_sym_mnemonic_token7] = "mnemonic_token7",
  [aux_sym_mnemonic_token8] = "mnemonic_token8",
  [aux_sym_mnemonic_token9] = "mnemonic_token9",
  [aux_sym_mnemonic_token10] = "mnemonic_token10",
  [aux_sym_mnemonic_token11] = "mnemonic_token11",
  [aux_sym_mnemonic_token12] = "mnemonic_token12",
  [aux_sym_mnemonic_token13] = "mnemonic_token13",
  [aux_sym_mnemonic_token14] = "mnemonic_token14",
  [aux_sym_mnemonic_token15] = "mnemonic_token15",
  [aux_sym_mnemonic_token16] = "mnemonic_token16",
  [aux_sym_mnemonic_token17] = "mnemonic_token17",
  [aux_sym_mnemonic_token18] = "mnemonic_token18",
  [aux_sym_mnemonic_token19] = "mnemonic_token19",
  [aux_sym_mnemonic_token20] = "mnemonic_token20",
  [aux_sym_mnemonic_token21] = "mnemonic_token21",
  [aux_sym_mnemonic_token22] = "mnemonic_token22",
  [aux_sym_mnemonic_token23] = "mnemonic_token23",
  [aux_sym_mnemonic_token24] = "mnemonic_token24",
  [aux_sym_mnemonic_token25] = "mnemonic_token25",
  [aux_sym_mnemonic_token26] = "mnemonic_token26",
  [aux_sym_mnemonic_token27] = "mnemonic_token27",
  [aux_sym_mnemonic_token28] = "mnemonic_token28",
  [aux_sym_mnemonic_token29] = "mnemonic_token29",
  [aux_sym_mnemonic_token30] = "mnemonic_token30",
  [aux_sym_mnemonic_token31] = "mnemonic_token31",
  [aux_sym_mnemonic_token32] = "mnemonic_token32",
  [aux_sym_mnemonic_token33] = "mnemonic_token33",
  [aux_sym_mnemonic_token34] = "mnemonic_token34",
  [aux_sym_mnemonic_token35] = "mnemonic_token35",
  [sym_comment] = "comment",
  [sym_other] = "other",
  [sym_source_file] = "source_file",
  [sym_row] = "row",
  [sym_instruction] = "instruction",
  [sym_instruction_number] = "instruction_number",
  [sym_instruction_code] = "instruction_code",
  [sym_mnemonic] = "mnemonic",
  [aux_sym_source_file_repeat1] = "source_file_repeat1",
  [aux_sym_row_repeat1] = "row_repeat1",
};

static const TSSymbol ts_symbol_map[] = {
  [ts_builtin_sym_end] = ts_builtin_sym_end,
  [aux_sym_row_token1] = aux_sym_row_token1,
  [aux_sym_instruction_number_token1] = aux_sym_instruction_number_token1,
  [sym_row_number] = sym_row_number,
  [aux_sym_mnemonic_token1] = aux_sym_mnemonic_token1,
  [aux_sym_mnemonic_token2] = aux_sym_mnemonic_token2,
  [aux_sym_mnemonic_token3] = aux_sym_mnemonic_token3,
  [aux_sym_mnemonic_token4] = aux_sym_mnemonic_token4,
  [aux_sym_mnemonic_token5] = aux_sym_mnemonic_token5,
  [aux_sym_mnemonic_token6] = aux_sym_mnemonic_token6,
  [aux_sym_mnemonic_token7] = aux_sym_mnemonic_token7,
  [aux_sym_mnemonic_token8] = aux_sym_mnemonic_token8,
  [aux_sym_mnemonic_token9] = aux_sym_mnemonic_token9,
  [aux_sym_mnemonic_token10] = aux_sym_mnemonic_token10,
  [aux_sym_mnemonic_token11] = aux_sym_mnemonic_token11,
  [aux_sym_mnemonic_token12] = aux_sym_mnemonic_token12,
  [aux_sym_mnemonic_token13] = aux_sym_mnemonic_token13,
  [aux_sym_mnemonic_token14] = aux_sym_mnemonic_token14,
  [aux_sym_mnemonic_token15] = aux_sym_mnemonic_token15,
  [aux_sym_mnemonic_token16] = aux_sym_mnemonic_token16,
  [aux_sym_mnemonic_token17] = aux_sym_mnemonic_token17,
  [aux_sym_mnemonic_token18] = aux_sym_mnemonic_token18,
  [aux_sym_mnemonic_token19] = aux_sym_mnemonic_token19,
  [aux_sym_mnemonic_token20] = aux_sym_mnemonic_token20,
  [aux_sym_mnemonic_token21] = aux_sym_mnemonic_token21,
  [aux_sym_mnemonic_token22] = aux_sym_mnemonic_token22,
  [aux_sym_mnemonic_token23] = aux_sym_mnemonic_token23,
  [aux_sym_mnemonic_token24] = aux_sym_mnemonic_token24,
  [aux_sym_mnemonic_token25] = aux_sym_mnemonic_token25,
  [aux_sym_mnemonic_token26] = aux_sym_mnemonic_token26,
  [aux_sym_mnemonic_token27] = aux_sym_mnemonic_token27,
  [aux_sym_mnemonic_token28] = aux_sym_mnemonic_token28,
  [aux_sym_mnemonic_token29] = aux_sym_mnemonic_token29,
  [aux_sym_mnemonic_token30] = aux_sym_mnemonic_token30,
  [aux_sym_mnemonic_token31] = aux_sym_mnemonic_token31,
  [aux_sym_mnemonic_token32] = aux_sym_mnemonic_token32,
  [aux_sym_mnemonic_token33] = aux_sym_mnemonic_token33,
  [aux_sym_mnemonic_token34] = aux_sym_mnemonic_token34,
  [aux_sym_mnemonic_token35] = aux_sym_mnemonic_token35,
  [sym_comment] = sym_comment,
  [sym_other] = sym_other,
  [sym_source_file] = sym_source_file,
  [sym_row] = sym_row,
  [sym_instruction] = sym_instruction,
  [sym_instruction_number] = sym_instruction_number,
  [sym_instruction_code] = sym_instruction_code,
  [sym_mnemonic] = sym_mnemonic,
  [aux_sym_source_file_repeat1] = aux_sym_source_file_repeat1,
  [aux_sym_row_repeat1] = aux_sym_row_repeat1,
};

static const TSSymbolMetadata ts_symbol_metadata[] = {
  [ts_builtin_sym_end] = {
    .visible = false,
    .named = true,
  },
  [aux_sym_row_token1] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_instruction_number_token1] = {
    .visible = false,
    .named = false,
  },
  [sym_row_number] = {
    .visible = true,
    .named = true,
  },
  [aux_sym_mnemonic_token1] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token2] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token3] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token4] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token5] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token6] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token7] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token8] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token9] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token10] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token11] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token12] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token13] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token14] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token15] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token16] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token17] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token18] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token19] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token20] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token21] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token22] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token23] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token24] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token25] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token26] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token27] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token28] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token29] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token30] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token31] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token32] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token33] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token34] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_mnemonic_token35] = {
    .visible = false,
    .named = false,
  },
  [sym_comment] = {
    .visible = true,
    .named = true,
  },
  [sym_other] = {
    .visible = true,
    .named = true,
  },
  [sym_source_file] = {
    .visible = true,
    .named = true,
  },
  [sym_row] = {
    .visible = true,
    .named = true,
  },
  [sym_instruction] = {
    .visible = true,
    .named = true,
  },
  [sym_instruction_number] = {
    .visible = true,
    .named = true,
  },
  [sym_instruction_code] = {
    .visible = true,
    .named = true,
  },
  [sym_mnemonic] = {
    .visible = true,
    .named = true,
  },
  [aux_sym_source_file_repeat1] = {
    .visible = false,
    .named = false,
  },
  [aux_sym_row_repeat1] = {
    .visible = false,
    .named = false,
  },
};

static const TSSymbol ts_alias_sequences[PRODUCTION_ID_COUNT][MAX_ALIAS_SEQUENCE_LENGTH] = {
  [0] = {0},
};

static const uint16_t ts_non_terminal_alias_map[] = {
  0,
};

static bool ts_lex(TSLexer *lexer, TSStateId state) {
  START_LEXER();
  eof = lexer->eof(lexer);
  switch (state) {
    case 0:
      if (eof) ADVANCE(86);
      if (lookahead == ';') ADVANCE(162);
      if (lookahead == 'A' ||
          lookahead == 'a') ADVANCE(10);
      if (lookahead == 'B' ||
          lookahead == 'b') ADVANCE(6);
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(3);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(13);
      if (lookahead == 'G' ||
          lookahead == 'g') ADVANCE(48);
      if (lookahead == 'I' ||
          lookahead == 'i') ADVANCE(47);
      if (lookahead == 'M' ||
          lookahead == 'm') ADVANCE(49);
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(50);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(15);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(39);
      if (lookahead == 'X' ||
          lookahead == 'x') ADVANCE(52);
      if (lookahead == '\t' ||
          lookahead == '\n' ||
          lookahead == '\r' ||
          lookahead == ' ') SKIP(0)
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(81);
      END_STATE();
    case 1:
      if (lookahead == '\t') ADVANCE(163);
      if (lookahead == '\n') ADVANCE(87);
      if (lookahead == ';') ADVANCE(162);
      if (lookahead == '\r' ||
          lookahead == ' ') SKIP(1)
      if (lookahead == 'A' ||
          lookahead == 'a') ADVANCE(171);
      if (lookahead == 'B' ||
          lookahead == 'b') ADVANCE(167);
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(164);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(174);
      if (lookahead == 'G' ||
          lookahead == 'g') ADVANCE(209);
      if (lookahead == 'I' ||
          lookahead == 'i') ADVANCE(208);
      if (lookahead == 'M' ||
          lookahead == 'm') ADVANCE(210);
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(211);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(176);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(200);
      if (lookahead == 'X' ||
          lookahead == 'x') ADVANCE(213);
      if (lookahead != 0) ADVANCE(235);
      END_STATE();
    case 2:
      if (lookahead == '\n') ADVANCE(88);
      if (lookahead == '\t' ||
          lookahead == '\r' ||
          lookahead == ' ') SKIP(2)
      END_STATE();
    case 3:
      if (lookahead == 'A' ||
          lookahead == 'a') ADVANCE(40);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(56);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(45);
      END_STATE();
    case 4:
      if (lookahead == 'A' ||
          lookahead == 'a') ADVANCE(55);
      END_STATE();
    case 5:
      if (lookahead == 'B' ||
          lookahead == 'b') ADVANCE(43);
      END_STATE();
    case 6:
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(18);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(19);
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(20);
      END_STATE();
    case 7:
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(132);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(134);
      END_STATE();
    case 8:
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(25);
      END_STATE();
    case 9:
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(26);
      END_STATE();
    case 10:
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(11);
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(12);
      END_STATE();
    case 11:
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(37);
      END_STATE();
    case 12:
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(41);
      END_STATE();
    case 13:
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(8);
      END_STATE();
    case 14:
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(150);
      END_STATE();
    case 15:
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(61);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(21);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(22);
      END_STATE();
    case 16:
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(17);
      END_STATE();
    case 17:
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(54);
      END_STATE();
    case 18:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(128);
      END_STATE();
    case 19:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(130);
      END_STATE();
    case 20:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(60);
      END_STATE();
    case 21:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(118);
      END_STATE();
    case 22:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(120);
      END_STATE();
    case 23:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(96);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(98);
      END_STATE();
    case 24:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(100);
      END_STATE();
    case 25:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(102);
      END_STATE();
    case 26:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(106);
      END_STATE();
    case 27:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(112);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(68);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(32);
      END_STATE();
    case 28:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(36);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(69);
      if (lookahead == 'U' ||
          lookahead == 'u') ADVANCE(57);
      END_STATE();
    case 29:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(92);
      END_STATE();
    case 30:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(94);
      END_STATE();
    case 31:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(110);
      END_STATE();
    case 32:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(114);
      END_STATE();
    case 33:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(122);
      END_STATE();
    case 34:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(124);
      END_STATE();
    case 35:
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(126);
      END_STATE();
    case 36:
      if (lookahead == 'I' ||
          lookahead == 'i') ADVANCE(14);
      END_STATE();
    case 37:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(65);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(29);
      END_STATE();
    case 38:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(140);
      END_STATE();
    case 39:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(16);
      if (lookahead == 'U' ||
          lookahead == 'u') ADVANCE(5);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(4);
      END_STATE();
    case 40:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(38);
      END_STATE();
    case 41:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(66);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(30);
      END_STATE();
    case 42:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(67);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(31);
      END_STATE();
    case 43:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(70);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(33);
      END_STATE();
    case 44:
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(71);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(35);
      END_STATE();
    case 45:
      if (lookahead == 'M' ||
          lookahead == 'm') ADVANCE(24);
      END_STATE();
    case 46:
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(154);
      END_STATE();
    case 47:
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(9);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(58);
      END_STATE();
    case 48:
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(63);
      END_STATE();
    case 49:
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(64);
      END_STATE();
    case 50:
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(53);
      END_STATE();
    case 51:
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(144);
      END_STATE();
    case 52:
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(59);
      END_STATE();
    case 53:
      if (lookahead == 'P' ||
          lookahead == 'p') ADVANCE(116);
      END_STATE();
    case 54:
      if (lookahead == 'P' ||
          lookahead == 'p') ADVANCE(156);
      END_STATE();
    case 55:
      if (lookahead == 'P' ||
          lookahead == 'p') ADVANCE(34);
      END_STATE();
    case 56:
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(23);
      END_STATE();
    case 57:
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(46);
      END_STATE();
    case 58:
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(42);
      END_STATE();
    case 59:
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(44);
      END_STATE();
    case 60:
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(7);
      END_STATE();
    case 61:
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(28);
      END_STATE();
    case 62:
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(142);
      END_STATE();
    case 63:
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(51);
      END_STATE();
    case 64:
      if (lookahead == 'V' ||
          lookahead == 'v') ADVANCE(27);
      END_STATE();
    case 65:
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(136);
      END_STATE();
    case 66:
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(138);
      END_STATE();
    case 67:
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(146);
      END_STATE();
    case 68:
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(148);
      END_STATE();
    case 69:
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(152);
      END_STATE();
    case 70:
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(158);
      END_STATE();
    case 71:
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(160);
      END_STATE();
    case 72:
      if (lookahead == 'Z' ||
          lookahead == 'z') ADVANCE(104);
      END_STATE();
    case 73:
      if (lookahead == 'Z' ||
          lookahead == 'z') ADVANCE(108);
      END_STATE();
    case 74:
      if (lookahead == '\t' ||
          lookahead == '\n' ||
          lookahead == '\r' ||
          lookahead == ' ') SKIP(74)
      if (('0' <= lookahead && lookahead <= '9') ||
          ('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(84);
      END_STATE();
    case 75:
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(91);
      END_STATE();
    case 76:
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(90);
      if (('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(89);
      END_STATE();
    case 77:
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(75);
      END_STATE();
    case 78:
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(76);
      if (('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(82);
      END_STATE();
    case 79:
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(77);
      END_STATE();
    case 80:
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(78);
      if (('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(83);
      END_STATE();
    case 81:
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(79);
      END_STATE();
    case 82:
      if (('0' <= lookahead && lookahead <= '9') ||
          ('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(89);
      END_STATE();
    case 83:
      if (('0' <= lookahead && lookahead <= '9') ||
          ('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(82);
      END_STATE();
    case 84:
      if (('0' <= lookahead && lookahead <= '9') ||
          ('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(83);
      END_STATE();
    case 85:
      if (eof) ADVANCE(86);
      if (lookahead == '\t' ||
          lookahead == '\n' ||
          lookahead == '\r' ||
          lookahead == ' ') SKIP(85)
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(80);
      if (('A' <= lookahead && lookahead <= 'F') ||
          ('a' <= lookahead && lookahead <= 'f')) ADVANCE(84);
      END_STATE();
    case 86:
      ACCEPT_TOKEN(ts_builtin_sym_end);
      END_STATE();
    case 87:
      ACCEPT_TOKEN(aux_sym_row_token1);
      if (lookahead == '\t') ADVANCE(163);
      if (lookahead == '\n') ADVANCE(87);
      END_STATE();
    case 88:
      ACCEPT_TOKEN(aux_sym_row_token1);
      if (lookahead == '\n') ADVANCE(88);
      END_STATE();
    case 89:
      ACCEPT_TOKEN(aux_sym_instruction_number_token1);
      END_STATE();
    case 90:
      ACCEPT_TOKEN(aux_sym_instruction_number_token1);
      if (('0' <= lookahead && lookahead <= '9')) ADVANCE(91);
      END_STATE();
    case 91:
      ACCEPT_TOKEN(sym_row_number);
      END_STATE();
    case 92:
      ACCEPT_TOKEN(aux_sym_mnemonic_token1);
      END_STATE();
    case 93:
      ACCEPT_TOKEN(aux_sym_mnemonic_token1);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 94:
      ACCEPT_TOKEN(aux_sym_mnemonic_token2);
      END_STATE();
    case 95:
      ACCEPT_TOKEN(aux_sym_mnemonic_token2);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 96:
      ACCEPT_TOKEN(aux_sym_mnemonic_token3);
      END_STATE();
    case 97:
      ACCEPT_TOKEN(aux_sym_mnemonic_token3);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 98:
      ACCEPT_TOKEN(aux_sym_mnemonic_token4);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(62);
      END_STATE();
    case 99:
      ACCEPT_TOKEN(aux_sym_mnemonic_token4);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(223);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 100:
      ACCEPT_TOKEN(aux_sym_mnemonic_token5);
      END_STATE();
    case 101:
      ACCEPT_TOKEN(aux_sym_mnemonic_token5);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 102:
      ACCEPT_TOKEN(aux_sym_mnemonic_token6);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(72);
      END_STATE();
    case 103:
      ACCEPT_TOKEN(aux_sym_mnemonic_token6);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(233);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 104:
      ACCEPT_TOKEN(aux_sym_mnemonic_token7);
      END_STATE();
    case 105:
      ACCEPT_TOKEN(aux_sym_mnemonic_token7);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 106:
      ACCEPT_TOKEN(aux_sym_mnemonic_token8);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(73);
      END_STATE();
    case 107:
      ACCEPT_TOKEN(aux_sym_mnemonic_token8);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(234);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 108:
      ACCEPT_TOKEN(aux_sym_mnemonic_token9);
      END_STATE();
    case 109:
      ACCEPT_TOKEN(aux_sym_mnemonic_token9);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 110:
      ACCEPT_TOKEN(aux_sym_mnemonic_token10);
      END_STATE();
    case 111:
      ACCEPT_TOKEN(aux_sym_mnemonic_token10);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 112:
      ACCEPT_TOKEN(aux_sym_mnemonic_token11);
      END_STATE();
    case 113:
      ACCEPT_TOKEN(aux_sym_mnemonic_token11);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 114:
      ACCEPT_TOKEN(aux_sym_mnemonic_token12);
      END_STATE();
    case 115:
      ACCEPT_TOKEN(aux_sym_mnemonic_token12);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 116:
      ACCEPT_TOKEN(aux_sym_mnemonic_token13);
      END_STATE();
    case 117:
      ACCEPT_TOKEN(aux_sym_mnemonic_token13);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 118:
      ACCEPT_TOKEN(aux_sym_mnemonic_token14);
      END_STATE();
    case 119:
      ACCEPT_TOKEN(aux_sym_mnemonic_token14);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 120:
      ACCEPT_TOKEN(aux_sym_mnemonic_token15);
      END_STATE();
    case 121:
      ACCEPT_TOKEN(aux_sym_mnemonic_token15);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 122:
      ACCEPT_TOKEN(aux_sym_mnemonic_token16);
      END_STATE();
    case 123:
      ACCEPT_TOKEN(aux_sym_mnemonic_token16);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 124:
      ACCEPT_TOKEN(aux_sym_mnemonic_token17);
      END_STATE();
    case 125:
      ACCEPT_TOKEN(aux_sym_mnemonic_token17);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 126:
      ACCEPT_TOKEN(aux_sym_mnemonic_token18);
      END_STATE();
    case 127:
      ACCEPT_TOKEN(aux_sym_mnemonic_token18);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 128:
      ACCEPT_TOKEN(aux_sym_mnemonic_token19);
      END_STATE();
    case 129:
      ACCEPT_TOKEN(aux_sym_mnemonic_token19);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 130:
      ACCEPT_TOKEN(aux_sym_mnemonic_token20);
      END_STATE();
    case 131:
      ACCEPT_TOKEN(aux_sym_mnemonic_token20);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 132:
      ACCEPT_TOKEN(aux_sym_mnemonic_token21);
      END_STATE();
    case 133:
      ACCEPT_TOKEN(aux_sym_mnemonic_token21);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 134:
      ACCEPT_TOKEN(aux_sym_mnemonic_token22);
      END_STATE();
    case 135:
      ACCEPT_TOKEN(aux_sym_mnemonic_token22);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 136:
      ACCEPT_TOKEN(aux_sym_mnemonic_token23);
      END_STATE();
    case 137:
      ACCEPT_TOKEN(aux_sym_mnemonic_token23);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 138:
      ACCEPT_TOKEN(aux_sym_mnemonic_token24);
      END_STATE();
    case 139:
      ACCEPT_TOKEN(aux_sym_mnemonic_token24);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 140:
      ACCEPT_TOKEN(aux_sym_mnemonic_token25);
      END_STATE();
    case 141:
      ACCEPT_TOKEN(aux_sym_mnemonic_token25);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 142:
      ACCEPT_TOKEN(aux_sym_mnemonic_token26);
      END_STATE();
    case 143:
      ACCEPT_TOKEN(aux_sym_mnemonic_token26);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 144:
      ACCEPT_TOKEN(aux_sym_mnemonic_token27);
      END_STATE();
    case 145:
      ACCEPT_TOKEN(aux_sym_mnemonic_token27);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 146:
      ACCEPT_TOKEN(aux_sym_mnemonic_token28);
      END_STATE();
    case 147:
      ACCEPT_TOKEN(aux_sym_mnemonic_token28);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 148:
      ACCEPT_TOKEN(aux_sym_mnemonic_token29);
      END_STATE();
    case 149:
      ACCEPT_TOKEN(aux_sym_mnemonic_token29);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 150:
      ACCEPT_TOKEN(aux_sym_mnemonic_token30);
      END_STATE();
    case 151:
      ACCEPT_TOKEN(aux_sym_mnemonic_token30);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 152:
      ACCEPT_TOKEN(aux_sym_mnemonic_token31);
      END_STATE();
    case 153:
      ACCEPT_TOKEN(aux_sym_mnemonic_token31);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 154:
      ACCEPT_TOKEN(aux_sym_mnemonic_token32);
      END_STATE();
    case 155:
      ACCEPT_TOKEN(aux_sym_mnemonic_token32);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 156:
      ACCEPT_TOKEN(aux_sym_mnemonic_token33);
      END_STATE();
    case 157:
      ACCEPT_TOKEN(aux_sym_mnemonic_token33);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 158:
      ACCEPT_TOKEN(aux_sym_mnemonic_token34);
      END_STATE();
    case 159:
      ACCEPT_TOKEN(aux_sym_mnemonic_token34);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 160:
      ACCEPT_TOKEN(aux_sym_mnemonic_token35);
      END_STATE();
    case 161:
      ACCEPT_TOKEN(aux_sym_mnemonic_token35);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 162:
      ACCEPT_TOKEN(sym_comment);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r') ADVANCE(162);
      END_STATE();
    case 163:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == '\t') ADVANCE(163);
      if (lookahead == '\n') ADVANCE(87);
      if (lookahead == 'A' ||
          lookahead == 'a') ADVANCE(171);
      if (lookahead == 'B' ||
          lookahead == 'b') ADVANCE(167);
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(164);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(174);
      if (lookahead == 'G' ||
          lookahead == 'g') ADVANCE(209);
      if (lookahead == 'I' ||
          lookahead == 'i') ADVANCE(208);
      if (lookahead == 'M' ||
          lookahead == 'm') ADVANCE(210);
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(211);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(176);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(200);
      if (lookahead == 'X' ||
          lookahead == 'x') ADVANCE(213);
      if (lookahead != 0 &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 164:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'A' ||
          lookahead == 'a') ADVANCE(201);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(217);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(206);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 165:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'A' ||
          lookahead == 'a') ADVANCE(216);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 166:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'B' ||
          lookahead == 'b') ADVANCE(204);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 167:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(179);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(180);
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(181);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 168:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(133);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(135);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 169:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(186);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 170:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'C' ||
          lookahead == 'c') ADVANCE(187);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 171:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(172);
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(173);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 172:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(198);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 173:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'D' ||
          lookahead == 'd') ADVANCE(202);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 174:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(169);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 175:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(151);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 176:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(222);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(182);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(183);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 177:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(178);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 178:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'E' ||
          lookahead == 'e') ADVANCE(215);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 179:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(129);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 180:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(131);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 181:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(221);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 182:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(119);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 183:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(121);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 184:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(97);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(99);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 185:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(101);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 186:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(103);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 187:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(107);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 188:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(113);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(229);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(193);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 189:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(197);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(230);
      if (lookahead == 'U' ||
          lookahead == 'u') ADVANCE(218);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 190:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(93);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 191:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(95);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 192:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(111);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 193:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(115);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 194:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(123);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 195:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(125);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 196:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'F' ||
          lookahead == 'f') ADVANCE(127);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 197:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'I' ||
          lookahead == 'i') ADVANCE(175);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 198:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(226);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(190);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 199:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(141);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 200:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(177);
      if (lookahead == 'U' ||
          lookahead == 'u') ADVANCE(166);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(165);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 201:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(199);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 202:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(227);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(191);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 203:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(228);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(192);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 204:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(231);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(194);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 205:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'L' ||
          lookahead == 'l') ADVANCE(232);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(196);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 206:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'M' ||
          lookahead == 'm') ADVANCE(185);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 207:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(155);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 208:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'N' ||
          lookahead == 'n') ADVANCE(170);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(219);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 209:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(224);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 210:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(225);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 211:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(214);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 212:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(145);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 213:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'O' ||
          lookahead == 'o') ADVANCE(220);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 214:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'P' ||
          lookahead == 'p') ADVANCE(117);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 215:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'P' ||
          lookahead == 'p') ADVANCE(157);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 216:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'P' ||
          lookahead == 'p') ADVANCE(195);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 217:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(184);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 218:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(207);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 219:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(203);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 220:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'R' ||
          lookahead == 'r') ADVANCE(205);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 221:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'S' ||
          lookahead == 's') ADVANCE(168);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 222:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(189);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 223:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(143);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 224:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'T' ||
          lookahead == 't') ADVANCE(212);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 225:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'V' ||
          lookahead == 'v') ADVANCE(188);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 226:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(137);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 227:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(139);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 228:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(147);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 229:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(149);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 230:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(153);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 231:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(159);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 232:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'W' ||
          lookahead == 'w') ADVANCE(161);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 233:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'Z' ||
          lookahead == 'z') ADVANCE(105);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 234:
      ACCEPT_TOKEN(sym_other);
      if (lookahead == 'Z' ||
          lookahead == 'z') ADVANCE(109);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    case 235:
      ACCEPT_TOKEN(sym_other);
      if (lookahead != 0 &&
          lookahead != '\n' &&
          lookahead != '\r' &&
          lookahead != ' ' &&
          lookahead != ';') ADVANCE(235);
      END_STATE();
    default:
      return false;
  }
}

static const TSLexMode ts_lex_modes[STATE_COUNT] = {
  [0] = {.lex_state = 0},
  [1] = {.lex_state = 85},
  [2] = {.lex_state = 1},
  [3] = {.lex_state = 1},
  [4] = {.lex_state = 1},
  [5] = {.lex_state = 1},
  [6] = {.lex_state = 1},
  [7] = {.lex_state = 1},
  [8] = {.lex_state = 85},
  [9] = {.lex_state = 85},
  [10] = {.lex_state = 85},
  [11] = {.lex_state = 85},
  [12] = {.lex_state = 85},
  [13] = {.lex_state = 85},
  [14] = {.lex_state = 74},
  [15] = {.lex_state = 0},
  [16] = {.lex_state = 0},
  [17] = {.lex_state = 2},
  [18] = {.lex_state = 0},
  [19] = {.lex_state = 74},
  [20] = {.lex_state = 2},
  [21] = {.lex_state = 2},
  [22] = {.lex_state = 0},
};

static const uint16_t ts_parse_table[LARGE_STATE_COUNT][SYMBOL_COUNT] = {
  [0] = {
    [ts_builtin_sym_end] = ACTIONS(1),
    [sym_row_number] = ACTIONS(1),
    [aux_sym_mnemonic_token1] = ACTIONS(1),
    [aux_sym_mnemonic_token2] = ACTIONS(1),
    [aux_sym_mnemonic_token3] = ACTIONS(1),
    [aux_sym_mnemonic_token4] = ACTIONS(1),
    [aux_sym_mnemonic_token5] = ACTIONS(1),
    [aux_sym_mnemonic_token6] = ACTIONS(1),
    [aux_sym_mnemonic_token7] = ACTIONS(1),
    [aux_sym_mnemonic_token8] = ACTIONS(1),
    [aux_sym_mnemonic_token9] = ACTIONS(1),
    [aux_sym_mnemonic_token10] = ACTIONS(1),
    [aux_sym_mnemonic_token11] = ACTIONS(1),
    [aux_sym_mnemonic_token12] = ACTIONS(1),
    [aux_sym_mnemonic_token13] = ACTIONS(1),
    [aux_sym_mnemonic_token14] = ACTIONS(1),
    [aux_sym_mnemonic_token15] = ACTIONS(1),
    [aux_sym_mnemonic_token16] = ACTIONS(1),
    [aux_sym_mnemonic_token17] = ACTIONS(1),
    [aux_sym_mnemonic_token18] = ACTIONS(1),
    [aux_sym_mnemonic_token19] = ACTIONS(1),
    [aux_sym_mnemonic_token20] = ACTIONS(1),
    [aux_sym_mnemonic_token21] = ACTIONS(1),
    [aux_sym_mnemonic_token22] = ACTIONS(1),
    [aux_sym_mnemonic_token23] = ACTIONS(1),
    [aux_sym_mnemonic_token24] = ACTIONS(1),
    [aux_sym_mnemonic_token25] = ACTIONS(1),
    [aux_sym_mnemonic_token26] = ACTIONS(1),
    [aux_sym_mnemonic_token27] = ACTIONS(1),
    [aux_sym_mnemonic_token28] = ACTIONS(1),
    [aux_sym_mnemonic_token29] = ACTIONS(1),
    [aux_sym_mnemonic_token30] = ACTIONS(1),
    [aux_sym_mnemonic_token31] = ACTIONS(1),
    [aux_sym_mnemonic_token32] = ACTIONS(1),
    [aux_sym_mnemonic_token33] = ACTIONS(1),
    [aux_sym_mnemonic_token34] = ACTIONS(1),
    [aux_sym_mnemonic_token35] = ACTIONS(1),
    [sym_comment] = ACTIONS(1),
  },
  [1] = {
    [sym_source_file] = STATE(22),
    [sym_row] = STATE(8),
    [sym_instruction] = STATE(15),
    [sym_instruction_number] = STATE(14),
    [aux_sym_source_file_repeat1] = STATE(8),
    [ts_builtin_sym_end] = ACTIONS(3),
    [aux_sym_instruction_number_token1] = ACTIONS(5),
    [sym_row_number] = ACTIONS(7),
  },
  [2] = {
    [sym_mnemonic] = STATE(2),
    [aux_sym_row_repeat1] = STATE(2),
    [aux_sym_row_token1] = ACTIONS(9),
    [aux_sym_mnemonic_token1] = ACTIONS(11),
    [aux_sym_mnemonic_token2] = ACTIONS(11),
    [aux_sym_mnemonic_token3] = ACTIONS(11),
    [aux_sym_mnemonic_token4] = ACTIONS(11),
    [aux_sym_mnemonic_token5] = ACTIONS(11),
    [aux_sym_mnemonic_token6] = ACTIONS(11),
    [aux_sym_mnemonic_token7] = ACTIONS(11),
    [aux_sym_mnemonic_token8] = ACTIONS(11),
    [aux_sym_mnemonic_token9] = ACTIONS(11),
    [aux_sym_mnemonic_token10] = ACTIONS(11),
    [aux_sym_mnemonic_token11] = ACTIONS(11),
    [aux_sym_mnemonic_token12] = ACTIONS(11),
    [aux_sym_mnemonic_token13] = ACTIONS(11),
    [aux_sym_mnemonic_token14] = ACTIONS(11),
    [aux_sym_mnemonic_token15] = ACTIONS(11),
    [aux_sym_mnemonic_token16] = ACTIONS(11),
    [aux_sym_mnemonic_token17] = ACTIONS(11),
    [aux_sym_mnemonic_token18] = ACTIONS(11),
    [aux_sym_mnemonic_token19] = ACTIONS(11),
    [aux_sym_mnemonic_token20] = ACTIONS(11),
    [aux_sym_mnemonic_token21] = ACTIONS(11),
    [aux_sym_mnemonic_token22] = ACTIONS(11),
    [aux_sym_mnemonic_token23] = ACTIONS(11),
    [aux_sym_mnemonic_token24] = ACTIONS(11),
    [aux_sym_mnemonic_token25] = ACTIONS(11),
    [aux_sym_mnemonic_token26] = ACTIONS(11),
    [aux_sym_mnemonic_token27] = ACTIONS(11),
    [aux_sym_mnemonic_token28] = ACTIONS(11),
    [aux_sym_mnemonic_token29] = ACTIONS(11),
    [aux_sym_mnemonic_token30] = ACTIONS(11),
    [aux_sym_mnemonic_token31] = ACTIONS(11),
    [aux_sym_mnemonic_token32] = ACTIONS(11),
    [aux_sym_mnemonic_token33] = ACTIONS(11),
    [aux_sym_mnemonic_token34] = ACTIONS(11),
    [aux_sym_mnemonic_token35] = ACTIONS(11),
    [sym_comment] = ACTIONS(9),
    [sym_other] = ACTIONS(14),
  },
  [3] = {
    [sym_mnemonic] = STATE(5),
    [aux_sym_row_repeat1] = STATE(5),
    [aux_sym_row_token1] = ACTIONS(17),
    [aux_sym_mnemonic_token1] = ACTIONS(19),
    [aux_sym_mnemonic_token2] = ACTIONS(19),
    [aux_sym_mnemonic_token3] = ACTIONS(19),
    [aux_sym_mnemonic_token4] = ACTIONS(19),
    [aux_sym_mnemonic_token5] = ACTIONS(19),
    [aux_sym_mnemonic_token6] = ACTIONS(19),
    [aux_sym_mnemonic_token7] = ACTIONS(19),
    [aux_sym_mnemonic_token8] = ACTIONS(19),
    [aux_sym_mnemonic_token9] = ACTIONS(19),
    [aux_sym_mnemonic_token10] = ACTIONS(19),
    [aux_sym_mnemonic_token11] = ACTIONS(19),
    [aux_sym_mnemonic_token12] = ACTIONS(19),
    [aux_sym_mnemonic_token13] = ACTIONS(19),
    [aux_sym_mnemonic_token14] = ACTIONS(19),
    [aux_sym_mnemonic_token15] = ACTIONS(19),
    [aux_sym_mnemonic_token16] = ACTIONS(19),
    [aux_sym_mnemonic_token17] = ACTIONS(19),
    [aux_sym_mnemonic_token18] = ACTIONS(19),
    [aux_sym_mnemonic_token19] = ACTIONS(19),
    [aux_sym_mnemonic_token20] = ACTIONS(19),
    [aux_sym_mnemonic_token21] = ACTIONS(19),
    [aux_sym_mnemonic_token22] = ACTIONS(19),
    [aux_sym_mnemonic_token23] = ACTIONS(19),
    [aux_sym_mnemonic_token24] = ACTIONS(19),
    [aux_sym_mnemonic_token25] = ACTIONS(19),
    [aux_sym_mnemonic_token26] = ACTIONS(19),
    [aux_sym_mnemonic_token27] = ACTIONS(19),
    [aux_sym_mnemonic_token28] = ACTIONS(19),
    [aux_sym_mnemonic_token29] = ACTIONS(19),
    [aux_sym_mnemonic_token30] = ACTIONS(19),
    [aux_sym_mnemonic_token31] = ACTIONS(19),
    [aux_sym_mnemonic_token32] = ACTIONS(19),
    [aux_sym_mnemonic_token33] = ACTIONS(19),
    [aux_sym_mnemonic_token34] = ACTIONS(19),
    [aux_sym_mnemonic_token35] = ACTIONS(19),
    [sym_comment] = ACTIONS(21),
    [sym_other] = ACTIONS(23),
  },
  [4] = {
    [sym_mnemonic] = STATE(2),
    [aux_sym_row_repeat1] = STATE(2),
    [aux_sym_row_token1] = ACTIONS(25),
    [aux_sym_mnemonic_token1] = ACTIONS(19),
    [aux_sym_mnemonic_token2] = ACTIONS(19),
    [aux_sym_mnemonic_token3] = ACTIONS(19),
    [aux_sym_mnemonic_token4] = ACTIONS(19),
    [aux_sym_mnemonic_token5] = ACTIONS(19),
    [aux_sym_mnemonic_token6] = ACTIONS(19),
    [aux_sym_mnemonic_token7] = ACTIONS(19),
    [aux_sym_mnemonic_token8] = ACTIONS(19),
    [aux_sym_mnemonic_token9] = ACTIONS(19),
    [aux_sym_mnemonic_token10] = ACTIONS(19),
    [aux_sym_mnemonic_token11] = ACTIONS(19),
    [aux_sym_mnemonic_token12] = ACTIONS(19),
    [aux_sym_mnemonic_token13] = ACTIONS(19),
    [aux_sym_mnemonic_token14] = ACTIONS(19),
    [aux_sym_mnemonic_token15] = ACTIONS(19),
    [aux_sym_mnemonic_token16] = ACTIONS(19),
    [aux_sym_mnemonic_token17] = ACTIONS(19),
    [aux_sym_mnemonic_token18] = ACTIONS(19),
    [aux_sym_mnemonic_token19] = ACTIONS(19),
    [aux_sym_mnemonic_token20] = ACTIONS(19),
    [aux_sym_mnemonic_token21] = ACTIONS(19),
    [aux_sym_mnemonic_token22] = ACTIONS(19),
    [aux_sym_mnemonic_token23] = ACTIONS(19),
    [aux_sym_mnemonic_token24] = ACTIONS(19),
    [aux_sym_mnemonic_token25] = ACTIONS(19),
    [aux_sym_mnemonic_token26] = ACTIONS(19),
    [aux_sym_mnemonic_token27] = ACTIONS(19),
    [aux_sym_mnemonic_token28] = ACTIONS(19),
    [aux_sym_mnemonic_token29] = ACTIONS(19),
    [aux_sym_mnemonic_token30] = ACTIONS(19),
    [aux_sym_mnemonic_token31] = ACTIONS(19),
    [aux_sym_mnemonic_token32] = ACTIONS(19),
    [aux_sym_mnemonic_token33] = ACTIONS(19),
    [aux_sym_mnemonic_token34] = ACTIONS(19),
    [aux_sym_mnemonic_token35] = ACTIONS(19),
    [sym_comment] = ACTIONS(27),
    [sym_other] = ACTIONS(29),
  },
  [5] = {
    [sym_mnemonic] = STATE(2),
    [aux_sym_row_repeat1] = STATE(2),
    [aux_sym_row_token1] = ACTIONS(31),
    [aux_sym_mnemonic_token1] = ACTIONS(19),
    [aux_sym_mnemonic_token2] = ACTIONS(19),
    [aux_sym_mnemonic_token3] = ACTIONS(19),
    [aux_sym_mnemonic_token4] = ACTIONS(19),
    [aux_sym_mnemonic_token5] = ACTIONS(19),
    [aux_sym_mnemonic_token6] = ACTIONS(19),
    [aux_sym_mnemonic_token7] = ACTIONS(19),
    [aux_sym_mnemonic_token8] = ACTIONS(19),
    [aux_sym_mnemonic_token9] = ACTIONS(19),
    [aux_sym_mnemonic_token10] = ACTIONS(19),
    [aux_sym_mnemonic_token11] = ACTIONS(19),
    [aux_sym_mnemonic_token12] = ACTIONS(19),
    [aux_sym_mnemonic_token13] = ACTIONS(19),
    [aux_sym_mnemonic_token14] = ACTIONS(19),
    [aux_sym_mnemonic_token15] = ACTIONS(19),
    [aux_sym_mnemonic_token16] = ACTIONS(19),
    [aux_sym_mnemonic_token17] = ACTIONS(19),
    [aux_sym_mnemonic_token18] = ACTIONS(19),
    [aux_sym_mnemonic_token19] = ACTIONS(19),
    [aux_sym_mnemonic_token20] = ACTIONS(19),
    [aux_sym_mnemonic_token21] = ACTIONS(19),
    [aux_sym_mnemonic_token22] = ACTIONS(19),
    [aux_sym_mnemonic_token23] = ACTIONS(19),
    [aux_sym_mnemonic_token24] = ACTIONS(19),
    [aux_sym_mnemonic_token25] = ACTIONS(19),
    [aux_sym_mnemonic_token26] = ACTIONS(19),
    [aux_sym_mnemonic_token27] = ACTIONS(19),
    [aux_sym_mnemonic_token28] = ACTIONS(19),
    [aux_sym_mnemonic_token29] = ACTIONS(19),
    [aux_sym_mnemonic_token30] = ACTIONS(19),
    [aux_sym_mnemonic_token31] = ACTIONS(19),
    [aux_sym_mnemonic_token32] = ACTIONS(19),
    [aux_sym_mnemonic_token33] = ACTIONS(19),
    [aux_sym_mnemonic_token34] = ACTIONS(19),
    [aux_sym_mnemonic_token35] = ACTIONS(19),
    [sym_comment] = ACTIONS(33),
    [sym_other] = ACTIONS(29),
  },
  [6] = {
    [sym_mnemonic] = STATE(4),
    [aux_sym_row_repeat1] = STATE(4),
    [aux_sym_row_token1] = ACTIONS(31),
    [aux_sym_mnemonic_token1] = ACTIONS(19),
    [aux_sym_mnemonic_token2] = ACTIONS(19),
    [aux_sym_mnemonic_token3] = ACTIONS(19),
    [aux_sym_mnemonic_token4] = ACTIONS(19),
    [aux_sym_mnemonic_token5] = ACTIONS(19),
    [aux_sym_mnemonic_token6] = ACTIONS(19),
    [aux_sym_mnemonic_token7] = ACTIONS(19),
    [aux_sym_mnemonic_token8] = ACTIONS(19),
    [aux_sym_mnemonic_token9] = ACTIONS(19),
    [aux_sym_mnemonic_token10] = ACTIONS(19),
    [aux_sym_mnemonic_token11] = ACTIONS(19),
    [aux_sym_mnemonic_token12] = ACTIONS(19),
    [aux_sym_mnemonic_token13] = ACTIONS(19),
    [aux_sym_mnemonic_token14] = ACTIONS(19),
    [aux_sym_mnemonic_token15] = ACTIONS(19),
    [aux_sym_mnemonic_token16] = ACTIONS(19),
    [aux_sym_mnemonic_token17] = ACTIONS(19),
    [aux_sym_mnemonic_token18] = ACTIONS(19),
    [aux_sym_mnemonic_token19] = ACTIONS(19),
    [aux_sym_mnemonic_token20] = ACTIONS(19),
    [aux_sym_mnemonic_token21] = ACTIONS(19),
    [aux_sym_mnemonic_token22] = ACTIONS(19),
    [aux_sym_mnemonic_token23] = ACTIONS(19),
    [aux_sym_mnemonic_token24] = ACTIONS(19),
    [aux_sym_mnemonic_token25] = ACTIONS(19),
    [aux_sym_mnemonic_token26] = ACTIONS(19),
    [aux_sym_mnemonic_token27] = ACTIONS(19),
    [aux_sym_mnemonic_token28] = ACTIONS(19),
    [aux_sym_mnemonic_token29] = ACTIONS(19),
    [aux_sym_mnemonic_token30] = ACTIONS(19),
    [aux_sym_mnemonic_token31] = ACTIONS(19),
    [aux_sym_mnemonic_token32] = ACTIONS(19),
    [aux_sym_mnemonic_token33] = ACTIONS(19),
    [aux_sym_mnemonic_token34] = ACTIONS(19),
    [aux_sym_mnemonic_token35] = ACTIONS(19),
    [sym_comment] = ACTIONS(33),
    [sym_other] = ACTIONS(35),
  },
  [7] = {
    [aux_sym_row_token1] = ACTIONS(37),
    [aux_sym_mnemonic_token1] = ACTIONS(37),
    [aux_sym_mnemonic_token2] = ACTIONS(37),
    [aux_sym_mnemonic_token3] = ACTIONS(37),
    [aux_sym_mnemonic_token4] = ACTIONS(37),
    [aux_sym_mnemonic_token5] = ACTIONS(37),
    [aux_sym_mnemonic_token6] = ACTIONS(37),
    [aux_sym_mnemonic_token7] = ACTIONS(37),
    [aux_sym_mnemonic_token8] = ACTIONS(37),
    [aux_sym_mnemonic_token9] = ACTIONS(37),
    [aux_sym_mnemonic_token10] = ACTIONS(37),
    [aux_sym_mnemonic_token11] = ACTIONS(37),
    [aux_sym_mnemonic_token12] = ACTIONS(37),
    [aux_sym_mnemonic_token13] = ACTIONS(37),
    [aux_sym_mnemonic_token14] = ACTIONS(37),
    [aux_sym_mnemonic_token15] = ACTIONS(37),
    [aux_sym_mnemonic_token16] = ACTIONS(37),
    [aux_sym_mnemonic_token17] = ACTIONS(37),
    [aux_sym_mnemonic_token18] = ACTIONS(37),
    [aux_sym_mnemonic_token19] = ACTIONS(37),
    [aux_sym_mnemonic_token20] = ACTIONS(37),
    [aux_sym_mnemonic_token21] = ACTIONS(37),
    [aux_sym_mnemonic_token22] = ACTIONS(37),
    [aux_sym_mnemonic_token23] = ACTIONS(37),
    [aux_sym_mnemonic_token24] = ACTIONS(37),
    [aux_sym_mnemonic_token25] = ACTIONS(37),
    [aux_sym_mnemonic_token26] = ACTIONS(37),
    [aux_sym_mnemonic_token27] = ACTIONS(37),
    [aux_sym_mnemonic_token28] = ACTIONS(37),
    [aux_sym_mnemonic_token29] = ACTIONS(37),
    [aux_sym_mnemonic_token30] = ACTIONS(37),
    [aux_sym_mnemonic_token31] = ACTIONS(37),
    [aux_sym_mnemonic_token32] = ACTIONS(37),
    [aux_sym_mnemonic_token33] = ACTIONS(37),
    [aux_sym_mnemonic_token34] = ACTIONS(37),
    [aux_sym_mnemonic_token35] = ACTIONS(37),
    [sym_comment] = ACTIONS(37),
    [sym_other] = ACTIONS(37),
  },
};

static const uint16_t ts_small_parse_table[] = {
  [0] = 6,
    ACTIONS(5), 1,
      aux_sym_instruction_number_token1,
    ACTIONS(7), 1,
      sym_row_number,
    ACTIONS(39), 1,
      ts_builtin_sym_end,
    STATE(14), 1,
      sym_instruction_number,
    STATE(15), 1,
      sym_instruction,
    STATE(9), 2,
      sym_row,
      aux_sym_source_file_repeat1,
  [20] = 6,
    ACTIONS(41), 1,
      ts_builtin_sym_end,
    ACTIONS(43), 1,
      aux_sym_instruction_number_token1,
    ACTIONS(46), 1,
      sym_row_number,
    STATE(14), 1,
      sym_instruction_number,
    STATE(15), 1,
      sym_instruction,
    STATE(9), 2,
      sym_row,
      aux_sym_source_file_repeat1,
  [40] = 2,
    ACTIONS(51), 1,
      aux_sym_instruction_number_token1,
    ACTIONS(49), 2,
      ts_builtin_sym_end,
      sym_row_number,
  [48] = 2,
    ACTIONS(55), 1,
      aux_sym_instruction_number_token1,
    ACTIONS(53), 2,
      ts_builtin_sym_end,
      sym_row_number,
  [56] = 2,
    ACTIONS(59), 1,
      aux_sym_instruction_number_token1,
    ACTIONS(57), 2,
      ts_builtin_sym_end,
      sym_row_number,
  [64] = 2,
    ACTIONS(63), 1,
      aux_sym_instruction_number_token1,
    ACTIONS(61), 2,
      ts_builtin_sym_end,
      sym_row_number,
  [72] = 2,
    ACTIONS(65), 1,
      aux_sym_instruction_number_token1,
    STATE(16), 1,
      sym_instruction_code,
  [79] = 1,
    ACTIONS(67), 1,
      sym_row_number,
  [83] = 1,
    ACTIONS(69), 1,
      sym_row_number,
  [87] = 1,
    ACTIONS(71), 1,
      aux_sym_row_token1,
  [91] = 1,
    ACTIONS(73), 1,
      sym_row_number,
  [95] = 1,
    ACTIONS(75), 1,
      aux_sym_instruction_number_token1,
  [99] = 1,
    ACTIONS(77), 1,
      aux_sym_row_token1,
  [103] = 1,
    ACTIONS(79), 1,
      aux_sym_row_token1,
  [107] = 1,
    ACTIONS(81), 1,
      ts_builtin_sym_end,
};

static const uint32_t ts_small_parse_table_map[] = {
  [SMALL_STATE(8)] = 0,
  [SMALL_STATE(9)] = 20,
  [SMALL_STATE(10)] = 40,
  [SMALL_STATE(11)] = 48,
  [SMALL_STATE(12)] = 56,
  [SMALL_STATE(13)] = 64,
  [SMALL_STATE(14)] = 72,
  [SMALL_STATE(15)] = 79,
  [SMALL_STATE(16)] = 83,
  [SMALL_STATE(17)] = 87,
  [SMALL_STATE(18)] = 91,
  [SMALL_STATE(19)] = 95,
  [SMALL_STATE(20)] = 99,
  [SMALL_STATE(21)] = 103,
  [SMALL_STATE(22)] = 107,
};

static const TSParseActionEntry ts_parse_actions[] = {
  [0] = {.entry = {.count = 0, .reusable = false}},
  [1] = {.entry = {.count = 1, .reusable = false}}, RECOVER(),
  [3] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_source_file, 0),
  [5] = {.entry = {.count = 1, .reusable = false}}, SHIFT(19),
  [7] = {.entry = {.count = 1, .reusable = true}}, SHIFT(3),
  [9] = {.entry = {.count = 1, .reusable = false}}, REDUCE(aux_sym_row_repeat1, 2),
  [11] = {.entry = {.count = 2, .reusable = false}}, REDUCE(aux_sym_row_repeat1, 2), SHIFT_REPEAT(7),
  [14] = {.entry = {.count = 2, .reusable = false}}, REDUCE(aux_sym_row_repeat1, 2), SHIFT_REPEAT(2),
  [17] = {.entry = {.count = 1, .reusable = false}}, SHIFT(12),
  [19] = {.entry = {.count = 1, .reusable = false}}, SHIFT(7),
  [21] = {.entry = {.count = 1, .reusable = false}}, SHIFT(20),
  [23] = {.entry = {.count = 1, .reusable = false}}, SHIFT(5),
  [25] = {.entry = {.count = 1, .reusable = false}}, SHIFT(11),
  [27] = {.entry = {.count = 1, .reusable = false}}, SHIFT(21),
  [29] = {.entry = {.count = 1, .reusable = false}}, SHIFT(2),
  [31] = {.entry = {.count = 1, .reusable = false}}, SHIFT(13),
  [33] = {.entry = {.count = 1, .reusable = false}}, SHIFT(17),
  [35] = {.entry = {.count = 1, .reusable = false}}, SHIFT(4),
  [37] = {.entry = {.count = 1, .reusable = false}}, REDUCE(sym_mnemonic, 1),
  [39] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_source_file, 1),
  [41] = {.entry = {.count = 1, .reusable = true}}, REDUCE(aux_sym_source_file_repeat1, 2),
  [43] = {.entry = {.count = 2, .reusable = false}}, REDUCE(aux_sym_source_file_repeat1, 2), SHIFT_REPEAT(19),
  [46] = {.entry = {.count = 2, .reusable = true}}, REDUCE(aux_sym_source_file_repeat1, 2), SHIFT_REPEAT(3),
  [49] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_row, 5),
  [51] = {.entry = {.count = 1, .reusable = false}}, REDUCE(sym_row, 5),
  [53] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_row, 4),
  [55] = {.entry = {.count = 1, .reusable = false}}, REDUCE(sym_row, 4),
  [57] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_row, 2),
  [59] = {.entry = {.count = 1, .reusable = false}}, REDUCE(sym_row, 2),
  [61] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_row, 3),
  [63] = {.entry = {.count = 1, .reusable = false}}, REDUCE(sym_row, 3),
  [65] = {.entry = {.count = 1, .reusable = true}}, SHIFT(18),
  [67] = {.entry = {.count = 1, .reusable = true}}, SHIFT(6),
  [69] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_instruction, 2),
  [71] = {.entry = {.count = 1, .reusable = true}}, SHIFT(11),
  [73] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_instruction_code, 1),
  [75] = {.entry = {.count = 1, .reusable = true}}, REDUCE(sym_instruction_number, 1),
  [77] = {.entry = {.count = 1, .reusable = true}}, SHIFT(13),
  [79] = {.entry = {.count = 1, .reusable = true}}, SHIFT(10),
  [81] = {.entry = {.count = 1, .reusable = true}},  ACCEPT_INPUT(),
};

#ifdef __cplusplus
extern "C" {
#endif
#ifdef _WIN32
#define extern __declspec(dllexport)
#endif

extern const TSLanguage *tree_sitter_pic(void) {
  static const TSLanguage language = {
    .version = LANGUAGE_VERSION,
    .symbol_count = SYMBOL_COUNT,
    .alias_count = ALIAS_COUNT,
    .token_count = TOKEN_COUNT,
    .external_token_count = EXTERNAL_TOKEN_COUNT,
    .state_count = STATE_COUNT,
    .large_state_count = LARGE_STATE_COUNT,
    .production_id_count = PRODUCTION_ID_COUNT,
    .field_count = FIELD_COUNT,
    .max_alias_sequence_length = MAX_ALIAS_SEQUENCE_LENGTH,
    .parse_table = &ts_parse_table[0][0],
    .small_parse_table = ts_small_parse_table,
    .small_parse_table_map = ts_small_parse_table_map,
    .parse_actions = ts_parse_actions,
    .symbol_names = ts_symbol_names,
    .symbol_metadata = ts_symbol_metadata,
    .public_symbol_map = ts_symbol_map,
    .alias_map = ts_non_terminal_alias_map,
    .alias_sequences = &ts_alias_sequences[0][0],
    .lex_modes = ts_lex_modes,
    .lex_fn = ts_lex,
  };
  return &language;
}
#ifdef __cplusplus
}
#endif

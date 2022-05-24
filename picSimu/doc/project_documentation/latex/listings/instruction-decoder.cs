if (binaryString.StartsWith("000111"))
    return new ADDWF(binaryString, pic);
if (binaryString.StartsWith("000101"))
    return new ANDWF(binaryString, pic);
if (binaryString.StartsWith("0000011"))
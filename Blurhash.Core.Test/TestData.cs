namespace Blurhash.Tests
{
    public class TestData
    {
        public static (int ComponentsX, int ComponentsY, string Hash, byte[] Data)[] Data = new[]
        {
            (1, 1, "00FFaX", new byte[] { 0, 0, 15, 15, 36, 33 }),
            (1, 2, "9CFFaX_{", new byte[] { 9, 12, 15, 15, 36, 33, 78, 79 }),
            (1, 3, "ICFFaX_{{1", new byte[] { 18, 12, 15, 15, 36, 33, 78, 79, 79, 1 }),
            (1, 4, "RHFFaX@-@[};", new byte[] { 27, 17, 15, 15, 36, 33, 74, 68, 74, 75, 81, 71 }),
            (1, 5, "aHFFaX@-@[};jM", new byte[] { 36, 17, 15, 15, 36, 33, 74, 68, 74, 75, 81, 71, 45, 22 }),
            (1, 6, "jHFFaX@-@[};jMj]", new byte[] { 45, 17, 15, 15, 36, 33, 74, 68, 74, 75, 81, 71, 45, 22, 45, 76 }),
            (1, 7, "sHFFaX@-@[};jMj]XB",
                new byte[] { 54, 17, 15, 15, 36, 33, 74, 68, 74, 75, 81, 71, 45, 22, 45, 76, 33, 11 }),
            (1, 8, "$HFFaX@-@[};jMj]XBXm",
                new byte[] { 63, 17, 15, 15, 36, 33, 74, 68, 74, 75, 81, 71, 45, 22, 45, 76, 33, 11, 33, 48 }),
            (1, 9, "=HFFaX@-@[};jMj]XBXmxH",
                new byte[] { 72, 17, 15, 15, 36, 33, 74, 68, 74, 75, 81, 71, 45, 22, 45, 76, 33, 11, 33, 48, 59, 17 }),
            (2, 1, "1GFFaXYk", new byte[] { 1, 16, 15, 15, 36, 33, 34, 46 }),
            (2, 2, "AGFFaXYk@-5c", new byte[] { 10, 16, 15, 15, 36, 33, 34, 46, 74, 68, 5, 38 }),
            (2, 3, "JGFFaXYk@-5c@@or", new byte[] { 19, 16, 15, 15, 36, 33, 34, 46, 74, 68, 5, 38, 74, 74, 50, 53 }),
            (2, 4, "SHFFaXYk@-5b@[or};Fx",
                new byte[] { 28, 17, 15, 15, 36, 33, 34, 46, 74, 68, 5, 37, 74, 75, 50, 53, 81, 71, 15, 59 }),
            (2, 5, "bHFFaXYk@-5b@[or};FxjMFx",
                new byte[]
                {
                    37, 17, 15, 15, 36, 33, 34, 46, 74, 68, 5, 37, 74, 75, 50, 53, 81, 71, 15, 59, 45, 22, 15, 59
                }),
            (2, 6, "kHFFaXYk@-5b@[or};FxjMFxj]OY",
                new byte[]
                {
                    46, 17, 15, 15, 36, 33, 34, 46, 74, 68, 5, 37, 74, 75, 50, 53, 81, 71, 15, 59, 45, 22, 15, 59, 45,
                    76, 24, 34
                }),
            (2, 7, "tHFFaXYk@-5b@[or};FxjMFxj]OYXBIp",
                new byte[]
                {
                    55, 17, 15, 15, 36, 33, 34, 46, 74, 68, 5, 37, 74, 75, 50, 53, 81, 71, 15, 59, 45, 22, 15, 59, 45,
                    76, 24, 34, 33, 11, 18, 51
                }),
            (2, 8, "%HFFaXYk@-5b@[or};FxjMFxj]OYXBIpXmxZ",
                new byte[]
                {
                    64, 17, 15, 15, 36, 33, 34, 46, 74, 68, 5, 37, 74, 75, 50, 53, 81, 71, 15, 59, 45, 22, 15, 59, 45,
                    76, 24, 34, 33, 11, 18, 51, 33, 48, 59, 35
                }),
            (2, 9, "?HFFaXYk@-5b@[or};FxjMFxj]OYXBIpXmxZxHnN",
                new byte[]
                {
                    73, 17, 15, 15, 36, 33, 34, 46, 74, 68, 5, 37, 74, 75, 50, 53, 81, 71, 15, 59, 45, 22, 15, 59, 45,
                    76, 24, 34, 33, 11, 18, 51, 33, 48, 59, 35, 59, 17, 49, 23
                }),
            (3, 1, "2GFFaXYk^6", new byte[] { 2, 16, 15, 15, 36, 33, 34, 46, 77, 6 }),
            (3, 2, "BGFFaXYk^6@-5c,1", new byte[] { 11, 16, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 38, 67, 1 }),
            (3, 3, "KGFFaXYk^6@-5c,1@@or[j",
                new byte[] { 20, 16, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 38, 67, 1, 74, 74, 50, 53, 75, 45 }),
            (3, 4, "THFFaXYk^6@-5b,1@[or[k};Fxi^",
                new byte[]
                {
                    29, 17, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 37, 67, 1, 74, 75, 50, 53, 75, 46, 81, 71, 15, 59,
                    44, 77
                }),
            (3, 5, "cHFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#",
                new byte[]
                {
                    38, 17, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 37, 67, 1, 74, 75, 50, 53, 75, 46, 81, 71, 15, 59,
                    44, 77, 45, 22, 15, 59, 28, 62
                }),
            (3, 6, "lHFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNe",
                new byte[]
                {
                    47, 17, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 37, 67, 1, 74, 75, 50, 53, 75, 46, 81, 71, 15, 59,
                    44, 77, 45, 22, 15, 59, 28, 62, 45, 76, 24, 34, 23, 40
                }),
            (3, 7, "uHFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNeXBIpNa",
                new byte[]
                {
                    56, 17, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 37, 67, 1, 74, 75, 50, 53, 75, 46, 81, 71, 15, 59,
                    44, 77, 45, 22, 15, 59, 28, 62, 45, 76, 24, 34, 23, 40, 33, 11, 18, 51, 23, 36
                }),
            (3, 8, "*HFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNeXBIpNaXmxZXS",
                new byte[]
                {
                    65, 17, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 37, 67, 1, 74, 75, 50, 53, 75, 46, 81, 71, 15, 59,
                    44, 77, 45, 22, 15, 59, 28, 62, 45, 76, 24, 34, 23, 40, 33, 11, 18, 51, 23, 36, 33, 48, 59, 35, 33,
                    28
                }),
            (3, 9, "@HFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNeXBIpNaXmxZXSxHnNV@",
                new byte[]
                {
                    74, 17, 15, 15, 36, 33, 34, 46, 77, 6, 74, 68, 5, 37, 67, 1, 74, 75, 50, 53, 75, 46, 81, 71, 15, 59,
                    44, 77, 45, 22, 15, 59, 28, 62, 45, 76, 24, 34, 23, 40, 33, 11, 18, 51, 23, 36, 33, 48, 59, 35, 33,
                    28, 59, 17, 49, 23, 31, 74
                }),
            (4, 1, "3GFFaXYk^6#M", new byte[] { 3, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22 }),
            (4, 2, "CGFFaXYk^6#M@-5c,1Ex",
                new byte[] { 12, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 38, 67, 1, 14, 59 }),
            (4, 3, "LGFFaXYk^6#M@-5c,1Ex@@or[j6o",
                new byte[]
                {
                    21, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 38, 67, 1, 14, 59, 74, 74, 50, 53, 75, 45,
                    6, 50
                }),
            (4, 4, "UHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZ",
                new byte[]
                {
                    30, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 37, 67, 1, 19, 5, 74, 75, 50, 53, 75, 46,
                    6, 50, 81, 71, 15, 59, 44, 77, 24, 35
                }),
            (4, 5, "dHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Ot",
                new byte[]
                {
                    39, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 37, 67, 1, 19, 5, 74, 75, 50, 53, 75, 46,
                    6, 50, 81, 71, 15, 59, 44, 77, 24, 35, 45, 22, 15, 59, 28, 62, 24, 55
                }),
            (4, 6, "mHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWG",
                new byte[]
                {
                    48, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 37, 67, 1, 19, 5, 74, 75, 50, 53, 75, 46,
                    6, 50, 81, 71, 15, 59, 44, 77, 24, 35, 45, 22, 15, 59, 28, 62, 24, 55, 45, 76, 24, 34, 23, 40, 32,
                    16
                }),
            (4, 7, "vHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWGXBIpNaxH",
                new byte[]
                {
                    57, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 37, 67, 1, 19, 5, 74, 75, 50, 53, 75, 46,
                    6, 50, 81, 71, 15, 59, 44, 77, 24, 35, 45, 22, 15, 59, 28, 62, 24, 55, 45, 76, 24, 34, 23, 40, 32,
                    16, 33, 11, 18, 51, 23, 36, 59, 17
                }),
            (4, 8, "+HFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWGXBIpNaxHXmxZXS$e",
                new byte[]
                {
                    66, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 37, 67, 1, 19, 5, 74, 75, 50, 53, 75, 46,
                    6, 50, 81, 71, 15, 59, 44, 77, 24, 35, 45, 22, 15, 59, 28, 62, 24, 55, 45, 76, 24, 34, 23, 40, 32,
                    16, 33, 11, 18, 51, 23, 36, 59, 17, 33, 48, 59, 35, 33, 28, 63, 40
                }),
            (4, 9, "[HFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWGXBIpNaxHXmxZXS$exHnNV@w{",
                new byte[]
                {
                    75, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 74, 68, 5, 37, 67, 1, 19, 5, 74, 75, 50, 53, 75, 46,
                    6, 50, 81, 71, 15, 59, 44, 77, 24, 35, 45, 22, 15, 59, 28, 62, 24, 55, 45, 76, 24, 34, 23, 40, 32,
                    16, 33, 11, 18, 51, 23, 36, 59, 17, 33, 48, 59, 35, 33, 28, 63, 40, 59, 17, 49, 23, 31, 74, 58, 79
                }),
            (5, 1, "4GFFaXYk^6#M9v", new byte[] { 4, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57 }),
            (5, 2, "DGFFaXYk^6#M9v@-5c,1ExPB",
                new byte[]
                {
                    13, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 38, 67, 1, 14, 59, 25, 11
                }),
            (5, 3, "MGFFaXYk^6#M9v@-5c,1ExPB@@or[j6oKk",
                new byte[]
                {
                    22, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 38, 67, 1, 14, 59, 25, 11, 74, 74,
                    50, 53, 75, 45, 6, 50, 20, 46
                }),
            (5, 4, "VHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3",
                new byte[]
                {
                    31, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11, 74, 75,
                    50, 53, 75, 46, 6, 50, 24, 75, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3
                }),
            (5, 5, "eHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcX",
                new byte[]
                {
                    40, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11, 74, 75,
                    50, 53, 75, 46, 6, 50, 24, 75, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 45, 22, 15, 59, 28, 62, 24,
                    55, 38, 33
                }),
            (5, 6, "nHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJC",
                new byte[]
                {
                    49, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11, 74, 75,
                    50, 53, 75, 46, 6, 50, 24, 75, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 45, 22, 15, 59, 28, 62, 24,
                    55, 38, 33, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12
                }),
            (5, 7, "wHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJCXBIpNaxHNG",
                new byte[]
                {
                    58, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11, 74, 75,
                    50, 53, 75, 46, 6, 50, 24, 75, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 45, 22, 15, 59, 28, 62, 24,
                    55, 38, 33, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16
                }),
            (5, 8, ",HFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJCXBIpNaxHNGXmxZXS$et6",
                new byte[]
                {
                    67, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11, 74, 75,
                    50, 53, 75, 46, 6, 50, 24, 75, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 45, 22, 15, 59, 28, 62, 24,
                    55, 38, 33, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 33, 48,
                    59, 35, 33, 28, 63, 40, 55, 6
                }),
            (5, 9, "]HFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJCXBIpNaxHNGXmxZXS$et6xHnNV@w{nO",
                new byte[]
                {
                    76, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11, 74, 75,
                    50, 53, 75, 46, 6, 50, 24, 75, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 45, 22, 15, 59, 28, 62, 24,
                    55, 38, 33, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 33, 48,
                    59, 35, 33, 28, 63, 40, 55, 6, 59, 17, 49, 23, 31, 74, 58, 79, 49, 24
                }),
            (6, 1, "5GFFaXYk^6#M9vF~", new byte[] { 5, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82 }),
            (6, 2, "EGFFaXYk^6#M9vF~@-5c,1ExPBV=",
                new byte[]
                {
                    14, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 38, 67, 1, 14, 59, 25, 11,
                    31, 72
                }),
            (6, 3, "NGFFaXYk^6#M9vF~@-5c,1ExPBV=@@or[j6oKkTL",
                new byte[]
                {
                    23, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 38, 67, 1, 14, 59, 25, 11,
                    31, 72, 74, 74, 50, 53, 75, 45, 6, 50, 20, 46, 29, 21
                }),
            (6, 4, "WHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3Ng",
                new byte[]
                {
                    32, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11,
                    31, 72, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42
                }),
            (6, 5, "fHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnz",
                new byte[]
                {
                    41, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11,
                    31, 72, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23,
                    42, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61
                }),
            (6, 6, "oHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9",
                new byte[]
                {
                    50, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11,
                    31, 72, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23,
                    42, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9
                }),
            (6, 7, "xHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9XBIpNaxHNGr;",
                new byte[]
                {
                    59, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11,
                    31, 72, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23,
                    42, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9,
                    33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71
                }),
            (6, 8,
                "-HFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9XBIpNaxHNGr;XmxZXS$et6#*",
                new byte[]
                {
                    68, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11,
                    31, 72, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23,
                    42, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9,
                    33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6, 62, 65
                }),
            (6, 9,
                "^HFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9XBIpNaxHNGr;XmxZXS$et6#*xHnNV@w{nOaK",
                new byte[]
                {
                    77, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 74, 68, 5, 37, 67, 1, 19, 5, 25, 11,
                    31, 72, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23,
                    42, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9,
                    33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6, 62, 65, 59,
                    17, 49, 23, 31, 74, 58, 79, 49, 24, 36, 20
                }),
            (7, 1, "6GFFaXYk^6#M9vF~W@",
                new byte[] { 6, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74 }),
            (7, 2, "FGFFaXYk^6#M9vF~W@@-5c,1ExPBV=Nf",
                new byte[]
                {
                    15, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 38, 67, 1, 14, 59,
                    25, 11, 31, 72, 23, 41
                }),
            (7, 3, "OGFFaXYk^6#M9vF~W@@-5c,1ExPBV=Nf@@or[j6oKkTLtI",
                new byte[]
                {
                    24, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 38, 67, 1, 14, 59,
                    25, 11, 31, 72, 23, 41, 74, 74, 50, 53, 75, 45, 6, 50, 20, 46, 29, 21, 55, 18
                }),
            (7, 4, "XHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}",
                new byte[]
                {
                    33, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 37, 67, 1, 19, 5,
                    25, 11, 31, 72, 27, 70, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 81, 71, 15, 59, 44,
                    77, 24, 35, 14, 3, 23, 42, 22, 81
                }),
            (7, 5, "gHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRj",
                new byte[]
                {
                    42, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 37, 67, 1, 19, 5,
                    25, 11, 31, 72, 27, 70, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 81, 71, 15, 59, 44,
                    77, 24, 35, 14, 3, 23, 42, 22, 81, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45
                }),
            (7, 6, "pHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xu",
                new byte[]
                {
                    51, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 37, 67, 1, 19, 5,
                    25, 11, 31, 72, 27, 70, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 81, 71, 15, 59, 44,
                    77, 24, 35, 14, 3, 23, 42, 22, 81, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 45, 76,
                    24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56
                }),
            (7, 7,
                "yHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xuXBIpNaxHNGr;v}",
                new byte[]
                {
                    60, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 37, 67, 1, 19, 5,
                    25, 11, 31, 72, 27, 70, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 81, 71, 15, 59, 44,
                    77, 24, 35, 14, 3, 23, 42, 22, 81, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 45, 76,
                    24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57,
                    81
                }),
            (7, 8,
                ".HFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xuXBIpNaxHNGr;v}XmxZXS$et6#*$f",
                new byte[]
                {
                    69, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 37, 67, 1, 19, 5,
                    25, 11, 31, 72, 27, 70, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 81, 71, 15, 59, 44,
                    77, 24, 35, 14, 3, 23, 42, 22, 81, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 45, 76,
                    24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57,
                    81, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6, 62, 65, 63, 41
                }),
            (7, 9,
                "_HFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xuXBIpNaxHNGr;v}XmxZXS$et6#*$fxHnNV@w{nOaKwf",
                new byte[]
                {
                    78, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 74, 68, 5, 37, 67, 1, 19, 5,
                    25, 11, 31, 72, 27, 70, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 81, 71, 15, 59, 44,
                    77, 24, 35, 14, 3, 23, 42, 22, 81, 45, 22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 45, 76,
                    24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57,
                    81, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6, 62, 65, 63, 41, 59, 17, 49, 23, 31, 74, 58, 79, 49, 24,
                    36, 20, 58, 41
                }),
            (8, 1, "7GFFaXYk^6#M9vF~W@j=",
                new byte[] { 7, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72 }),
            (8, 2, "GGFFaXYk^6#M9vF~W@j=@-5c,1ExPBV=Nfs;",
                new byte[]
                {
                    16, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 38, 67, 1,
                    14, 59, 25, 11, 31, 72, 23, 41, 54, 71
                }),
            (8, 3, "PGFFaXYk^6#M9vF~W@j=@-5c,1ExPBV=Nfs;@@or[j6oKkTLtIrp",
                new byte[]
                {
                    25, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 38, 67, 1,
                    14, 59, 25, 11, 31, 72, 23, 41, 54, 71, 74, 74, 50, 53, 75, 45, 6, 50, 20, 46, 29, 21, 55, 18, 53,
                    51
                }),
            (8, 4, "YHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}sp",
                new byte[]
                {
                    34, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 37, 67, 1,
                    19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 53,
                    52, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51
                }),
            (8, 5, "hHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZ",
                new byte[]
                {
                    43, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 37, 67, 1,
                    19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 53,
                    52, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 45, 22, 15, 59, 28, 62, 24, 55,
                    38, 33, 49, 61, 27, 45, 59, 35
                }),
            (8, 6,
                "qHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunh",
                new byte[]
                {
                    52, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 37, 67, 1,
                    19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 53,
                    52, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 45, 22, 15, 59, 28, 62, 24, 55,
                    38, 33, 49, 61, 27, 45, 59, 35, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56, 49, 43
                }),
            (8, 7,
                "zHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunhXBIpNaxHNGr;v}ae",
                new byte[]
                {
                    61, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 37, 67, 1,
                    19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 53,
                    52, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 45, 22, 15, 59, 28, 62, 24, 55,
                    38, 33, 49, 61, 27, 45, 59, 35, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56, 49, 43, 33,
                    11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57, 81, 36, 40
                }),
            (8, 8,
                ":HFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunhXBIpNaxHNGr;v}aeXmxZXS$et6#*$ft6",
                new byte[]
                {
                    70, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 37, 67, 1,
                    19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 53,
                    52, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 45, 22, 15, 59, 28, 62, 24, 55,
                    38, 33, 49, 61, 27, 45, 59, 35, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56, 49, 43, 33,
                    11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57, 81, 36, 40, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6,
                    62, 65, 63, 41, 55, 6
                }),
            (8, 9,
                "{HFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunhXBIpNaxHNGr;v}aeXmxZXS$et6#*$ft6xHnNV@w{nOaKwfNH",
                new byte[]
                {
                    79, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 74, 68, 5, 37, 67, 1,
                    19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21, 55, 19, 53,
                    52, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 45, 22, 15, 59, 28, 62, 24, 55,
                    38, 33, 49, 61, 27, 45, 59, 35, 45, 76, 24, 34, 23, 40, 32, 16, 19, 12, 54, 9, 59, 56, 49, 43, 33,
                    11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57, 81, 36, 40, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6,
                    62, 65, 63, 41, 55, 6, 59, 17, 49, 23, 31, 74, 58, 79, 49, 24, 36, 20, 58, 41, 23, 17
                }),
            (9, 1, "8GFFaXYk^6#M9vF~W@j=#*",
                new byte[] { 8, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65 }),
            (9, 2, "HGFFaXYk^6#M9vF~W@j=#*@-5c,1ExPBV=Nfs;w[",
                new byte[]
                {
                    17, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 38,
                    67, 1, 14, 59, 25, 11, 31, 72, 23, 41, 54, 71, 58, 75
                }),
            (9, 3, "QGFFaXYk^6#M9vF~W@j=#*@-5c,1ExPBV=Nfs;w[@@or[j6oKkTLtIrpnO",
                new byte[]
                {
                    26, 16, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 38,
                    67, 1, 14, 59, 25, 11, 31, 72, 23, 41, 54, 71, 58, 75, 74, 74, 50, 53, 75, 45, 6, 50, 20, 46, 29,
                    21, 55, 18, 53, 51, 49, 24
                }),
            (9, 4, "ZHFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,",
                new byte[]
                {
                    35, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 37,
                    67, 1, 19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 58, 75, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21,
                    55, 19, 53, 52, 49, 24, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 54, 67
                }),
            (9, 5, "iHFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxH",
                new byte[]
                {
                    44, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 37,
                    67, 1, 19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 58, 75, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21,
                    55, 19, 53, 52, 49, 24, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 54, 67, 45,
                    22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 59, 35, 59, 17
                }),
            (9, 6,
                "rHFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwI",
                new byte[]
                {
                    53, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 37,
                    67, 1, 19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 58, 75, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21,
                    55, 19, 53, 52, 49, 24, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 54, 67, 45,
                    22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 59, 35, 59, 17, 45, 76, 24, 34, 23, 40, 32, 16,
                    19, 12, 54, 9, 59, 56, 49, 43, 58, 18
                }),
            (9, 7,
                "#HFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwIXBIpNaxHNGr;v}aeo0",
                new byte[]
                {
                    62, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 37,
                    67, 1, 19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 58, 75, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21,
                    55, 19, 53, 52, 49, 24, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 54, 67, 45,
                    22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 59, 35, 59, 17, 45, 76, 24, 34, 23, 40, 32, 16,
                    19, 12, 54, 9, 59, 56, 49, 43, 58, 18, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57, 81, 36,
                    40, 50, 0
                }),
            (9, 8,
                ";HFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwIXBIpNaxHNGr;v}aeo0XmxZXS$et6#*$ft6nh",
                new byte[]
                {
                    71, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 37,
                    67, 1, 19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 58, 75, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21,
                    55, 19, 53, 52, 49, 24, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 54, 67, 45,
                    22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 59, 35, 59, 17, 45, 76, 24, 34, 23, 40, 32, 16,
                    19, 12, 54, 9, 59, 56, 49, 43, 58, 18, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57, 81, 36,
                    40, 50, 0, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6, 62, 65, 63, 41, 55, 6, 49, 43
                }),
            (9, 9,
                "|HFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwIXBIpNaxHNGr;v}aeo0XmxZXS$et6#*$ft6nhxHnNV@w{nOaKwfNHo0",
                new byte[]
                {
                    80, 17, 15, 15, 36, 33, 34, 46, 77, 6, 62, 22, 9, 57, 15, 82, 32, 74, 45, 72, 62, 65, 74, 68, 5, 37,
                    67, 1, 19, 5, 25, 11, 31, 72, 27, 70, 54, 71, 58, 75, 74, 75, 50, 53, 75, 46, 6, 50, 24, 75, 29, 21,
                    55, 19, 53, 52, 49, 24, 81, 71, 15, 59, 44, 77, 24, 35, 14, 3, 23, 42, 22, 81, 54, 51, 54, 67, 45,
                    22, 15, 59, 28, 62, 24, 55, 38, 33, 49, 61, 27, 45, 59, 35, 59, 17, 45, 76, 24, 34, 23, 40, 32, 16,
                    19, 12, 54, 9, 59, 56, 49, 43, 58, 18, 33, 11, 18, 51, 23, 36, 59, 17, 23, 16, 53, 71, 57, 81, 36,
                    40, 50, 0, 33, 48, 59, 35, 33, 28, 63, 40, 55, 6, 62, 65, 63, 41, 55, 6, 49, 43, 59, 17, 49, 23, 31,
                    74, 58, 79, 49, 24, 36, 20, 58, 41, 23, 17, 50, 0
                }),
        };
    }
}

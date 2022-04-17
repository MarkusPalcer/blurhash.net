using System.Collections.Generic;

namespace System.Drawing.Blurhash
{
    public class ImageConversionTestCases
    {
        public static IReadOnlyDictionary<(int, int), string> ExpectedHashes = new Dictionary<(int, int), string>
        {
            { (1, 1), "00FFaX" },
            { (1, 2), "9CFFaX_{" },
            { (1, 3), "ICFFaX_{{1" },
            { (1, 4), "RHFFaX@-@[};" },
            { (1, 5), "aHFFaX@-@[};jM" },
            { (1, 6), "jHFFaX@-@[};jMj]" },
            { (1, 7), "sHFFaX@-@[};jMj]XB" },
            { (1, 8), "$HFFaX@-@[};jMj]XBXm" },
            { (1, 9), "=HFFaX@-@[};jMj]XBXmxH" },
            { (2, 1), "1GFFaXYk" },
            { (2, 2), "AGFFaXYk@-5c" },
            { (2, 3), "JGFFaXYk@-5c@@or" },
            { (2, 4), "SHFFaXYk@-5b@[or};Fx" },
            { (2, 5), "bHFFaXYk@-5b@[or};FxjMFx" },
            { (2, 6), "kHFFaXYk@-5b@[or};FxjMFxj]OY" },
            { (2, 7), "tHFFaXYk@-5b@[or};FxjMFxj]OYXBIp" },
            { (2, 8), "%HFFaXYk@-5b@[or};FxjMFxj]OYXBIpXmxZ" },
            { (2, 9), "?HFFaXYk@-5b@[or};FxjMFxj]OYXBIpXmxZxHnN" },
            { (3, 1), "2GFFaXYk^6" },
            { (3, 2), "BGFFaXYk^6@-5c,1" },
            { (3, 3), "KGFFaXYk^6@-5c,1@@or[j" },
            { (3, 4), "THFFaXYk^6@-5b,1@[or[k};Fxi^" },
            { (3, 5), "cHFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#" },
            { (3, 6), "lHFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNe" },
            { (3, 7), "uHFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNeXBIpNa" },
            { (3, 8), "*HFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNeXBIpNaXmxZXS" },
            { (3, 9), "@HFFaXYk^6@-5b,1@[or[k};Fxi^jMFxS#j]OYNeXBIpNaXmxZXSxHnNV@" },
            { (4, 1), "3GFFaXYk^6#M" },
            { (4, 2), "CGFFaXYk^6#M@-5c,1Ex" },
            { (4, 3), "LGFFaXYk^6#M@-5c,1Ex@@or[j6o" },
            { (4, 4), "UHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZ" },
            { (4, 5), "dHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Ot" },
            { (4, 6), "mHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWG" },
            { (4, 7), "vHFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWGXBIpNaxH" },
            { (4, 8), "+HFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWGXBIpNaxHXmxZXS$e" },
            { (4, 9), "[HFFaXYk^6#M@-5b,1J5@[or[k6o};Fxi^OZjMFxS#Otj]OYNeWGXBIpNaxHXmxZXS$exHnNV@w{" },
            { (5, 1), "4GFFaXYk^6#M9v" },
            { (5, 2), "DGFFaXYk^6#M9v@-5c,1ExPB" },
            { (5, 3), "MGFFaXYk^6#M9v@-5c,1ExPB@@or[j6oKk" },
            { (5, 4), "VHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3" },
            { (5, 5), "eHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcX" },
            { (5, 6), "nHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJC" },
            { (5, 7), "wHFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJCXBIpNaxHNG" },
            { (5, 8), ",HFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJCXBIpNaxHNGXmxZXS$et6" },
            {
                (5, 9), "]HFFaXYk^6#M9v@-5b,1J5PB@[or[k6oO[};Fxi^OZE3jMFxS#OtcXj]OYNeWGJCXBIpNaxHNGXmxZXS$et6xHnNV@w{nO"
            },
            { (6, 1), "5GFFaXYk^6#M9vF~" },
            { (6, 2), "EGFFaXYk^6#M9vF~@-5c,1ExPBV=" },
            { (6, 3), "NGFFaXYk^6#M9vF~@-5c,1ExPBV=@@or[j6oKkTL" },
            { (6, 4), "WHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3Ng" },
            { (6, 5), "fHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnz" },
            { (6, 6), "oHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9" },
            { (6, 7), "xHFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9XBIpNaxHNGr;" },
            {
                (6, 8),
                "-HFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9XBIpNaxHNGr;XmxZXS$et6#*"
            },
            {
                (6, 9),
                "^HFFaXYk^6#M9vF~@-5b,1J5PBV=@[or[k6oO[TL};Fxi^OZE3NgjMFxS#OtcXnzj]OYNeWGJCs9XBIpNaxHNGr;XmxZXS$et6#*xHnNV@w{nOaK"
            },
            { (7, 1), "6GFFaXYk^6#M9vF~W@" },
            { (7, 2), "FGFFaXYk^6#M9vF~W@@-5c,1ExPBV=Nf" },
            { (7, 3), "OGFFaXYk^6#M9vF~W@@-5c,1ExPBV=Nf@@or[j6oKkTLtI" },
            { (7, 4), "XHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}" },
            { (7, 5), "gHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRj" },
            { (7, 6), "pHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xu" },
            {
                (7, 7),
                "yHFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xuXBIpNaxHNGr;v}"
            },
            {
                (7, 8),
                ".HFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xuXBIpNaxHNGr;v}XmxZXS$et6#*$f"
            },
            {
                (7, 9),
                "_HFFaXYk^6#M9vF~W@@-5b,1J5PBV=R:@[or[k6oO[TLtJ};Fxi^OZE3NgM}jMFxS#OtcXnzRjj]OYNeWGJCs9xuXBIpNaxHNGr;v}XmxZXS$et6#*$fxHnNV@w{nOaKwf"
            },
            { (8, 1), "7GFFaXYk^6#M9vF~W@j=" },
            { (8, 2), "GGFFaXYk^6#M9vF~W@j=@-5c,1ExPBV=Nfs;" },
            { (8, 3), "PGFFaXYk^6#M9vF~W@j=@-5c,1ExPBV=Nfs;@@or[j6oKkTLtIrp" },
            { (8, 4), "YHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}sp" },
            { (8, 5), "hHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZ" },
            {
                (8, 6),
                "qHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunh"
            },
            {
                (8, 7),
                "zHFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunhXBIpNaxHNGr;v}ae"
            },
            {
                (8, 8),
                ":HFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunhXBIpNaxHNGr;v}aeXmxZXS$et6#*$ft6"
            },
            {
                (8, 9),
                "{HFFaXYk^6#M9vF~W@j=@-5b,1J5PBV=R:s;@[or[k6oO[TLtJrq};Fxi^OZE3NgM}spjMFxS#OtcXnzRjxZj]OYNeWGJCs9xunhXBIpNaxHNGr;v}aeXmxZXS$et6#*$ft6xHnNV@w{nOaKwfNH"
            },
            { (9, 1), "8GFFaXYk^6#M9vF~W@j=#*" },
            { (9, 2), "HGFFaXYk^6#M9vF~W@j=#*@-5c,1ExPBV=Nfs;w[" },
            { (9, 3), "QGFFaXYk^6#M9vF~W@j=#*@-5c,1ExPBV=Nfs;w[@@or[j6oKkTLtIrpnO" },
            { (9, 4), "ZHFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps," },
            {
                (9, 5), "iHFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxH"
            },
            {
                (9, 6),
                "rHFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwI"
            },
            {
                (9, 7),
                "#HFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwIXBIpNaxHNGr;v}aeo0"
            },
            {
                (9, 8),
                ";HFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwIXBIpNaxHNGr;v}aeo0XmxZXS$et6#*$ft6nh"
            },
            {
                (9, 9),
                "|HFFaXYk^6#M9vF~W@j=#*@-5b,1J5PBV=R:s;w[@[or[k6oO[TLtJrqnO};Fxi^OZE3NgM}sps,jMFxS#OtcXnzRjxZxHj]OYNeWGJCs9xunhwIXBIpNaxHNGr;v}aeo0XmxZXS$et6#*$ft6nhxHnNV@w{nOaKwfNHo0"
            },
        };
    }
}

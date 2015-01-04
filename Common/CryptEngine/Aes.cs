using System;

namespace Common.CryptEngine
{
     /// <summary>
    /// Aes manipulator
     /// </summary>
    public class Aes // Advanced Encryption Standard
    {
        public enum KeySize
        {
            Bits128,
            Bits192,
            Bits256
        };

        private readonly byte[] _key; // the seed key. size will be 4 * keySize from ctor.
        private byte[,] _rcon; // Round constants.
        private byte[,] _state; // State matrix
        // key size, in bits, for construtor

        private int _nb; // block size in 32-bit words.  Always 4 for AES.  (128 bits).
        private int _nk; // key size in 32-bit words.  4, 6, 8.  (128, 192, 256 bits).
        private int _nr; // number of rounds. 10, 12, 14.

        private byte[,] _sbox; // Substitution box
        private byte[,] _iSbox; // inverse Substitution box 
        private byte[,] _w; // key schedule array. 

        public Aes(KeySize keySize, byte[] keyBytes)
        {
            SetNbNkNr(keySize);

            _key = new byte[_nk * 4]; // 16, 24, 32 bytes
            keyBytes.CopyTo(_key, 0);

            BuildSbox();
            BuildInvSbox();
            BuildRcon();
            KeyExpansion(); // expand the seed key into a key schedule and store in w
        } // Aes constructor

        public void Cipher(byte[] input, byte[] output) // encipher 16-bit input
        {
            // state = input
            _state = new byte[4, _nb]; // always [4,4]
            for (int i = 0; i < (4 * _nb); ++i)
            {
                _state[i % 4, i / 4] = input[i];
            }

            AddRoundKey(0);

            for (int round = 1; round <= (_nr - 1); ++round) // main round loop
            {
                SubBytes();
                ShiftRows();
                MixColumns();
                AddRoundKey(round);
            } // main round loop

            SubBytes();
            ShiftRows();
            AddRoundKey(_nr);

            // output = state
            for (int i = 0; i < (4 * _nb); ++i)
            {
                output[i] = _state[i % 4, i / 4];
            }
        } // Cipher()

        public void InvCipher(byte[] input, byte[] output) // decipher 16-bit input
        {
            // state = input
            _state = new byte[4, _nb]; // always [4,4]
            for (int i = 0; i < (4 * _nb); ++i)
            {
                _state[i % 4, i / 4] = input[i];
            }

            AddRoundKey(_nr);

            for (int round = _nr - 1; round >= 1; --round) // main round loop
            {
                InvShiftRows();
                InvSubBytes();
                AddRoundKey(round);
                InvMixColumns();
            } // end main round loop for InvCipher

            InvShiftRows();
            InvSubBytes();
            AddRoundKey(0);

            // output = state
            for (int i = 0; i < (4 * _nb); ++i)
            {
                output[i] = _state[i % 4, i / 4];
            }
        } // InvCipher()

        private void SetNbNkNr(KeySize keySize)
        {
            _nb = 4; // block size always = 4 words = 16 bytes = 128 bits for AES

            if (keySize == KeySize.Bits128)
            {
                _nk = 4; // key size = 4 words = 16 bytes = 128 bits
                _nr = 10; // rounds for algorithm = 10
            }
            else if (keySize == KeySize.Bits192)
            {
                _nk = 6; // 6 words = 24 bytes = 192 bits
                _nr = 12;
            }
            else if (keySize == KeySize.Bits256)
            {
                _nk = 8; // 8 words = 32 bytes = 256 bits
                _nr = 14;
            }
        } // SetNbNkNr()

        private void BuildSbox()
        {
            _sbox = new byte[,]
            {
                // populate the Sbox matrix
                /* 0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f */
                /*0*/  {0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76},
                /*1*/  {0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0},
                /*2*/  {0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15},
                /*3*/  {0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75},
                /*4*/  {0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84},
                /*5*/  {0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf},
                /*6*/  {0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8},
                /*7*/  {0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2},
                /*8*/  {0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73},
                /*9*/  {0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb},
                /*a*/  {0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79},
                /*b*/  {0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08},
                /*c*/  {0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a},
                /*d*/  {0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e},
                /*e*/  {0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf},
                /*f*/  {0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16}
            };
        } // BuildSbox() 

        private void BuildInvSbox()
        {
            _iSbox = new byte[,]
            {
                // populate the iSbox matrix
                /* 0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f */
                /*0*/  {0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb},
                /*1*/  {0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb},
                /*2*/  {0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e},
                /*3*/  {0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25},
                /*4*/  {0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92},
                /*5*/  {0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84},
                /*6*/  {0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06},
                /*7*/  {0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b},
                /*8*/  {0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73},
                /*9*/  {0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e},
                /*a*/  {0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b},
                /*b*/  {0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4},
                /*c*/  {0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f},
                /*d*/  {0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef},
                /*e*/  {0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61},
                /*f*/  {0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d}
            };
        } // BuildInvSbox()

        private void BuildRcon()
        {
            _rcon = new byte[,]
            {
                {0x00, 0x00, 0x00, 0x00},
                {0x01, 0x00, 0x00, 0x00},
                {0x02, 0x00, 0x00, 0x00},
                {0x04, 0x00, 0x00, 0x00},
                {0x08, 0x00, 0x00, 0x00},
                {0x10, 0x00, 0x00, 0x00},
                {0x20, 0x00, 0x00, 0x00},
                {0x40, 0x00, 0x00, 0x00},
                {0x80, 0x00, 0x00, 0x00},
                {0x1b, 0x00, 0x00, 0x00},
                {0x36, 0x00, 0x00, 0x00}
            };
        } // BuildRcon()

        private void AddRoundKey(int round)
        {
            for (var r = 0; r < 4; ++r)
            {
                for (var c = 0; c < 4; ++c)
                {
                    _state[r, c] = (byte)(_state[r, c] ^ _w[(round * 4) + c, r]);
                }
            }
        } // AddRoundKey()

        private void SubBytes()
        {
            for (var r = 0; r < 4; ++r)
            {
                for (var c = 0; c < 4; ++c)
                {
                    _state[r, c] = _sbox[(_state[r, c] >> 4), (_state[r, c] & 0x0f)];
                }
            }
        } // SubBytes

        private void InvSubBytes()
        {
            for (var r = 0; r < 4; ++r)
            {
                for (var c = 0; c < 4; ++c)
                {
                    _state[r, c] = _iSbox[(_state[r, c] >> 4), (_state[r, c] & 0x0f)];
                }
            }
        } // InvSubBytes

        private void ShiftRows()
        {
            var temp = new byte[4, 4];
            for (int r = 0; r < 4; ++r) // copy State into temp[]
            {
                for (int c = 0; c < 4; ++c)
                {
                    temp[r, c] = _state[r, c];
                }
            }

            for (int r = 1; r < 4; ++r) // shift temp into State
            {
                for (int c = 0; c < 4; ++c)
                {
                    _state[r, c] = temp[r, (c + r) % _nb];
                }
            }
        } // ShiftRows()

        private void InvShiftRows()
        {
            var temp = new byte[4, 4];
            for (int r = 0; r < 4; ++r) // copy State into temp[]
            {
                for (int c = 0; c < 4; ++c)
                {
                    temp[r, c] = _state[r, c];
                }
            }
            for (int r = 1; r < 4; ++r) // shift temp into State
            {
                for (int c = 0; c < 4; ++c)
                {
                    _state[r, (c + r) % _nb] = temp[r, c];
                }
            }
        } // InvShiftRows()

        private void MixColumns()
        {
            var temp = new byte[4, 4];
            for (int r = 0; r < 4; ++r) // copy State into temp[]
            {
                for (int c = 0; c < 4; ++c)
                {
                    temp[r, c] = _state[r, c];
                }
            }

            for (int c = 0; c < 4; ++c)
            {
                _state[0, c] = (byte)(Gfmultby02(temp[0, c]) ^ Gfmultby03(temp[1, c]) ^
                                      Gfmultby01(temp[2, c]) ^ Gfmultby01(temp[3, c]));
                _state[1, c] = (byte)(Gfmultby01(temp[0, c]) ^ Gfmultby02(temp[1, c]) ^
                                      Gfmultby03(temp[2, c]) ^ Gfmultby01(temp[3, c]));
                _state[2, c] = (byte)(Gfmultby01(temp[0, c]) ^ Gfmultby01(temp[1, c]) ^
                                      Gfmultby02(temp[2, c]) ^ Gfmultby03(temp[3, c]));
                _state[3, c] = (byte)(Gfmultby03(temp[0, c]) ^ Gfmultby01(temp[1, c]) ^
                                      Gfmultby01(temp[2, c]) ^ Gfmultby02(temp[3, c]));
            }
        } // MixColumns

        private void InvMixColumns()
        {
            var temp = new byte[4, 4];
            for (int r = 0; r < 4; ++r) // copy State into temp[]
            {
                for (int c = 0; c < 4; ++c)
                {
                    temp[r, c] = _state[r, c];
                }
            }

            for (int c = 0; c < 4; ++c)
            {
                _state[0, c] = (byte)(Gfmultby0E(temp[0, c]) ^ Gfmultby0B(temp[1, c]) ^
                                      Gfmultby0D(temp[2, c]) ^ Gfmultby09(temp[3, c]));
                _state[1, c] = (byte)(Gfmultby09(temp[0, c]) ^ Gfmultby0E(temp[1, c]) ^
                                      Gfmultby0B(temp[2, c]) ^ Gfmultby0D(temp[3, c]));
                _state[2, c] = (byte)(Gfmultby0D(temp[0, c]) ^ Gfmultby09(temp[1, c]) ^
                                      Gfmultby0E(temp[2, c]) ^ Gfmultby0B(temp[3, c]));
                _state[3, c] = (byte)(Gfmultby0B(temp[0, c]) ^ Gfmultby0D(temp[1, c]) ^
                                      Gfmultby09(temp[2, c]) ^ Gfmultby0E(temp[3, c]));
            }
        } // InvMixColumns

        private static byte Gfmultby01(byte b)
        {
            return b;
        }

        private static byte Gfmultby02(byte b)
        {
            if (b < 0x80)
                return (byte)(b << 1);
            return (byte)(b << 1 ^ 0x1b);
        }

        private static byte Gfmultby03(byte b)
        {
            return (byte)(Gfmultby02(b) ^ b);
        }

        private static byte Gfmultby09(byte b)
        {
            return (byte)(Gfmultby02(Gfmultby02(Gfmultby02(b))) ^
                           b);
        }

        private static byte Gfmultby0B(byte b)
        {
            return (byte)(Gfmultby02(Gfmultby02(Gfmultby02(b))) ^
                           Gfmultby02(b) ^
                           b);
        }

        private static byte Gfmultby0D(byte b)
        {
            return (byte)(Gfmultby02(Gfmultby02(Gfmultby02(b))) ^
                           Gfmultby02(Gfmultby02(b)) ^
                           b);
        }

        private static byte Gfmultby0E(byte b)
        {
            return (byte)(Gfmultby02(Gfmultby02(Gfmultby02(b))) ^
                           Gfmultby02(Gfmultby02(b)) ^
                           Gfmultby02(b));
        }

        private void KeyExpansion()
        {
            _w = new byte[_nb * (_nr + 1), 4]; // 4 columns of bytes corresponds to a word

            for (int row = 0; row < _nk; ++row)
            {
                _w[row, 0] = _key[4 * row];
                _w[row, 1] = _key[4 * row + 1];
                _w[row, 2] = _key[4 * row + 2];
                _w[row, 3] = _key[4 * row + 3];
            }

            var temp = new byte[4];

            for (int row = _nk; row < _nb * (_nr + 1); ++row)
            {
                temp[0] = _w[row - 1, 0];
                temp[1] = _w[row - 1, 1];
                temp[2] = _w[row - 1, 2];
                temp[3] = _w[row - 1, 3];

                if (row % _nk == 0)
                {
                    temp = SubWord(RotWord(temp));

                    temp[0] = (byte)(temp[0] ^ _rcon[row / _nk, 0]);
                    temp[1] = (byte)(temp[1] ^ _rcon[row / _nk, 1]);
                    temp[2] = (byte)(temp[2] ^ _rcon[row / _nk, 2]);
                    temp[3] = (byte)(temp[3] ^ _rcon[row / _nk, 3]);
                }
                else if (_nk > 6 && (row % _nk == 4))
                {
                    temp = SubWord(temp);
                }

                // w[row] = w[row-Nk] xor temp
                _w[row, 0] = (byte)(_w[row - _nk, 0] ^ temp[0]);
                _w[row, 1] = (byte)(_w[row - _nk, 1] ^ temp[1]);
                _w[row, 2] = (byte)(_w[row - _nk, 2] ^ temp[2]);
                _w[row, 3] = (byte)(_w[row - _nk, 3] ^ temp[3]);
            } // for loop
        } // KeyExpansion()

        private byte[] SubWord(byte[] word)
        {
            var result = new byte[4];
            result[0] = _sbox[word[0] >> 4, word[0] & 0x0f];
            result[1] = _sbox[word[1] >> 4, word[1] & 0x0f];
            result[2] = _sbox[word[2] >> 4, word[2] & 0x0f];
            result[3] = _sbox[word[3] >> 4, word[3] & 0x0f];
            return result;
        }

        private byte[] RotWord(byte[] word)
        {
            var result = new byte[4];
            result[0] = word[1];
            result[1] = word[2];
            result[2] = word[3];
            result[3] = word[0];
            return result;
        }

        public void Dump()
        {
            Console.WriteLine("Nb = " + _nb + " Nk = " + _nk + " Nr = " + _nr);
            Console.WriteLine("\nThe key is \n" + DumpKey());
            Console.WriteLine("\nThe Sbox is \n" + DumpTwoByTwo(_sbox));
            Console.WriteLine("\nThe w array is \n" + DumpTwoByTwo(_w));
            Console.WriteLine("\nThe State array is \n" + DumpTwoByTwo(_state));
        }

        public string DumpKey()
        {
            string s = "";
            for (int i = 0; i < _key.Length; ++i)
                s += _key[i].ToString("x2") + " ";
            return s;
        }

        public string DumpTwoByTwo(byte[,] a)
        {
            string s = "";
            for (int r = 0; r < a.GetLength(0); ++r)
            {
                s += "[" + r + "]" + " ";
                for (int c = 0; c < a.GetLength(1); ++c)
                {
                    s += a[r, c].ToString("x2") + " ";
                }
                s += "\n";
            }
            return s;
        }
    } // class Aes
}
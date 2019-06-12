 static void compressFile(string filePath, string compreessedFilePath)
        {
            using (FileStream inputStream = File.OpenRead(filePath))
            {
                using (var outputStream = File.OpenWrite(compreessedFilePath))
                {
                    using (var compressStream = new DeflateStream(outputStream, CompressionMode.Compress))
                    {
                        inputStream.CopyTo(compressStream);
                    }
                }
            }
        }
        static void DecompressFile(string filePath,string dstFilePath)
        {
            using (FileStream inputStream = File.OpenRead(filePath))
            {
                using (var outputStream = File.OpenWrite(dstFilePath))
                {
                    using (var compressStream = new DeflateStream(inputStream, CompressionMode.Decompress))
                    {
                        compressStream.CopyTo(outputStream);
                    }
                }
            }

        }
        static void zip( string[] filesPath, string zipPath)
        {
            using (FileStream zipStream = File.OpenWrite(zipPath))
            {
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    foreach(var filePath in filesPath)
                    {
                        ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(filePath));
                        using (FileStream inputStream = File.OpenRead(filePath))
                        using (var outputStream = entry.Open())
                        {
                            inputStream.CopyTo(outputStream);
                        }
                    }
                }
            }
        }
        static void dZip(string zipFilePath, string dstDir)
        {
            using (FileStream zipFileToOpen = new FileStream(zipFilePath, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipFileToOpen, ZipArchiveMode.Read))
                {
                    foreach (var entry in archive.Entries)
                    {
                        //ZipArchiveEntry entry = archive.GetEntry("ZipArchiveSample.exe");
                        Console.WriteLine(entry.FullName);
                        using (Stream stream = entry.Open())
                        {
                            Stream output = new FileStream(Path.Combine(dstDir, entry.FullName), FileMode.Create);
                            int b = -1;
                            while ((b = stream.ReadByte()) != -1)
                            {
                                output.WriteByte((byte)b);
                            }
                            output.Close();
                        }
                    }
                       
                }
            }
        }
        //SharpZipLib
        static void gz(string filePath, string compreessedFilePath)
        {
            using (FileStream inputStream = File.OpenRead(filePath))
            {
                using (var outputStream = File.OpenWrite(compreessedFilePath))
                {
                    using (var compressStream = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        inputStream.CopyTo(compressStream);
                    }
                }
            }
        }
        static void dGz(string filePath, string dstFilePath)
        {
            using (FileStream inputStream = File.OpenRead(filePath))
            {
                using (var outputStream = File.OpenWrite(dstFilePath))
                {
                    using (var compressStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        compressStream.CopyTo(outputStream);
                    }
                }
            }

        }

        static void tar(string[] filesPath, string tarPath)
        {
            using (FileStream zipStream = File.OpenWrite(tarPath))
            {
                using (var archive = TarArchive.CreateOutputTarArchive(zipStream, TarBuffer.DefaultBlockFactor))
                {
                    foreach (var filePath in filesPath)
                    {
                        var entry = TarEntry.CreateEntryFromFile(filePath);
                        entry.Name = Path.GetFileName(filePath);
                        archive.WriteEntry(entry, true);
                       
                    }
                }
            }
        }

        static void dTar(string tarFilePath, string dstDir)
        {
            using (FileStream zipFileToOpen = new FileStream(tarFilePath, FileMode.Open))
            {
                using (TarInputStream archive = new TarInputStream(zipFileToOpen))
                {
                    var entry = archive.GetNextEntry();
                    while (entry!=null)
                    {
                        Console.WriteLine(entry.Name);
                       
                        Stream output = new FileStream(Path.Combine(dstDir, entry.Name), FileMode.Create);
                        int b = -1;
                        while ((b = archive.ReadByte()) != -1)
                        {
                            output.WriteByte((byte)b);
                        }
                        output.Close();
                        entry = archive.GetNextEntry();
                    }

                }
            }
        }

        static void tarGz(string[] filesPath, string tarPath)
        {
            using (FileStream zipStream = File.OpenWrite(tarPath))
            {
                using (Stream outStream = new GZipOutputStream(zipStream))
                {
                    using (var archive = TarArchive.CreateOutputTarArchive(outStream, TarBuffer.DefaultBlockFactor))
                    {
                        foreach (var filePath in filesPath)
                        {
                            var entry = TarEntry.CreateEntryFromFile(filePath);
                            entry.Name = Path.GetFileName(filePath);
                            archive.WriteEntry(entry, true);

                        }
                    }
                }
                
            }
        }
        static void dTarGz(string tarFilePath, string dstDir)
        {
            using (FileStream zipFileToOpen = new FileStream(tarFilePath, FileMode.Open))
            {
                using (var gzipStream = new GZipInputStream(zipFileToOpen))
                {
                    using (TarInputStream archive = new TarInputStream(gzipStream))
                    {
                        var entry = archive.GetNextEntry();
                        while (entry != null)
                        {
                            Console.WriteLine(entry.Name);

                            Stream output = new FileStream(Path.Combine(dstDir, entry.Name), FileMode.Create);
                            int b = -1;
                            while ((b = archive.ReadByte()) != -1)
                            {
                                output.WriteByte((byte)b);
                            }
                            output.Close();
                            entry = archive.GetNextEntry();
                        }

                    }
                }
                
            }
        }

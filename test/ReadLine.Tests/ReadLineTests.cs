﻿/*
 * MIT License
 *
 * Copyright (c) 2017 Toni Solarin-Sodara
 * Copyright (c) 2022 EoflaOE and its companies
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */

using System;
using System.Linq;
using Xunit;

using static System.ReadLine;

namespace ReadLine.Tests
{
    public class ReadLineTests : IDisposable
    {
        public ReadLineTests()
        {
            string[] history = new string[] { "ls -a", "dotnet run", "git init" };
            AddHistory(history);
        }

        [Fact]
        public void TestNoInitialHistory() 
        {
            Assert.Equal(3, GetHistory().Count);
        }

        [Fact]
        public void TestUpdatesHistory() 
        {
            AddHistory("mkdir");
            Assert.Equal(4, GetHistory().Count);
            Assert.Equal("mkdir", GetHistory().Last());
        }

        [Fact]
        public void TestGetCorrectHistory() 
        {
            Assert.Equal("ls -a", GetHistory()[0]);
            Assert.Equal("dotnet run", GetHistory()[1]);
            Assert.Equal("git init", GetHistory()[2]);
        }

        public void Dispose()
        {
            // If all above tests pass
            // clear history works
            ClearHistory();
        }
    }
}

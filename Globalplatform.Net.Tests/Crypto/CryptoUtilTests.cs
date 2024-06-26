﻿using GlobalPlatform.Net.Crypto;
using NUnit.Framework;

namespace Globalplatform.Net.Tests.Crypto;

[TestFixture]
public class CryptoUtilTests
{
    [Test]
    // <summary>
    // Ensure AES padding rules are implemented properly.
    // </summary>
    public void TestAesPadding()
    {
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00 }),
            Is.EqualTo(new byte[]
                { 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01 }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02 }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03 }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04 }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 }),
            Is.EqualTo(new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 }),
            Is.EqualTo(new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 }),
            Is.EqualTo(new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00
            }));
        Assert.That(CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A }),
            Is.EqualTo(new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x80, 0x00, 0x00, 0x00, 0x00
            }));
        Assert.That(
            CryptoUtil.AESPad(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x80, 0x00, 0x00, 0x00 }));
        Assert.That(
            CryptoUtil.AESPad(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x80, 0x00, 0x00 }));
        Assert.That(
            CryptoUtil.AESPad(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x80, 0x00 }));
        Assert.That(
            CryptoUtil.AESPad(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E }),
            Is.EqualTo(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x80 }));
        Assert.That(
            CryptoUtil.AESPad(new byte[]
                { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }),
            Is.EqualTo(new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x80,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            }));
        Assert.That(
            CryptoUtil.AESPad(new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10
            }),
            Is.EqualTo(new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10,
                0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            }));
    }
}
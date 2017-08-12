﻿using NUnit.Framework;
using System;
using Snake.Framework.Texts;
using Rhino.Mocks;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests
{
	[TestFixture]
	public class TextSystemExtensionsTest
	{
		[Test]
		public void DrawCenter_Text_Centralized()
		{
			var target = MockRepository.GenerateMock<ITextSystem>();
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			target.Expect(t => t.GetFont("Default")).Return(font);
			target.Expect(t => t.Draw(13, 149.5f, "Test", "Default"));
			target.DrawCenter("Test", new Rectangle(10, 100, 20, 200), "Default");

			target.VerifyAllExpectations();
		}

		[Test]
		public void DrawCenter_OffsetAndText_OffsetCentralized()
		{
			var target = MockRepository.GenerateMock<ITextSystem>();
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			target.Expect(t => t.GetFont("Default")).Return(font);
			target.Expect(t => t.Draw(23, 169.5f, "Test", "Default"));
			target.DrawCenter(10, 20, "Test", new Rectangle(10, 100, 20, 200), "Default");

			target.VerifyAllExpectations();
		}

		[Test]
		public void DrawCenterX_YAndText_XCentralized()
		{
			var target = MockRepository.GenerateMock<ITextSystem>();
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			target.Expect(t => t.GetFont("Default")).Return(font);
			target.Expect(t => t.Draw(13, 10, "Test", "Default"));
			target.DrawCenterX(10, "Test", new Rectangle(10, 100, 20, 200), "Default");

			target.VerifyAllExpectations();
		}

		[Test]
		public void DrawCenterY_XAndText_YCentralized()
		{
			var target = MockRepository.GenerateMock<ITextSystem>();
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			target.Expect(t => t.GetFont("Default")).Return(font);
			target.Expect(t => t.Draw(10, 149.5f, "Test", "Default"));
			target.DrawCenterY(10, "Test", new Rectangle(10, 100, 20, 200), "Default");

			target.VerifyAllExpectations();
		}
	}
}

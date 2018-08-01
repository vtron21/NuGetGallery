﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NuGetGallery
{
    public class SymbolPackage
        : IEntity, IEquatable<SymbolPackage>
    {
        public int Key { get; set; }

        public Package Package { get; set; }

        public int PackageKey { get; set; }

        /// <summary>
        /// Timestamp when this symbol was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Time when this symbol package is available for consumption. It will be updated after validations are complete.
        /// </summary>
        public DateTime? Published { get; set; }

        /// <summary>
        /// The size of the snupkg file in bytes.
        /// </summary>
        public long FileSize { get; set; }

        [StringLength(10)]
        public string HashAlgorithm { get; set; }

        /// <summary>
        /// Stringified hashcode generated by hashing the snupkg file with HashAlgorithm.
        /// </summary>
        [StringLength(256)]
        [Required]
        public string Hash { get; set; }

        /// <summary>
        /// Availability status of the symbol
        /// </summary>
        public PackageStatus StatusKey { get; set; }

        /// <summary>
        /// Used for optimistic concurrency when updating the symbols.
        /// </summary>
        public byte[] RowVersion { get; set; }

        public bool Equals(SymbolPackage other)
        {
            return other.Key == Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            SymbolPackage sp = obj as SymbolPackage;
            if (sp == null)
            {
                return false;
            }

            return Equals(sp);
        }

        public static bool operator ==(SymbolPackage sp1, SymbolPackage sp2)
        {
            if (sp1 == null || sp2 == null)
            {
                return Equals(sp1, sp2);
            }

            return sp1.Equals(sp2);
        }

        public static bool operator !=(SymbolPackage sp1, SymbolPackage sp2)
        {
            if (sp1 == null || sp2 == null)
            {
                return !Equals(sp1, sp2);
            }

            return !sp1.Equals(sp2);
        }
    }
}
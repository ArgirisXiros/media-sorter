﻿using MediaSorter.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSorter.Core.Extensions;

public static class ContentTypeExtensions
{
    private static readonly HashSet<ContentType> ImageContentTypes = [ ContentType.jpg,
                                                                       ContentType.jpeg,
                                                                       ContentType.png,
                                                                       ContentType.gif ];

    private static readonly HashSet<ContentType> VideoContentTypes = [ContentType.mp4];

    public static bool IsImage(this ContentType type) => ImageContentTypes.Contains(type);

    public static bool IsVideo(this ContentType type) => VideoContentTypes.Contains(type);
}
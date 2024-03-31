using System;
using System.Collections.Generic;

namespace ThePaintingLoverApplication.Models
{
    public abstract class Style
    {
        public string Name { get; set; }
        public string InceptionYear { get; set; }
        public string Description { get; set; }
        public List<Painting> Paintings { get; set; }
    }
    public class Realism : Style
    {
        public Realism()
        {
            Name = "Realism";
            InceptionYear = "1850s";
            Description = "Realism is a painting art style that aims to give the viewer a reflection of the real world." +
                "This style, strange as it sounds today, was also a kind of revolution in art.Objective reality, accuracy," +
                " truth — that’s what inspired realist artists. At the same time, they opposed the emotionality of works of art," +
                " which was characteristic of romanticism.";
        }
    }

    public class Expressionism : Style
    {
        public Expressionism()
        {
            Name = "Expressionism";
            InceptionYear = "The first half of the 20th centuries";
            Description = "Expressionism is the artistic style in which the artist seeks to depict not objective reality" +
                " but rather the subjective emotions and responses that objects and events arouse within a person. " +
                "The artist accomplishes this aim through distortion, exaggeration, primitivism, and fantasy and through " +
                "the vivid, jarring, violent, or dynamic application of formal elements.";
        }
    }

    public class Impressionism : Style
    {
        public Impressionism()
        {
            Name = "Impressionism";
            InceptionYear = "The late 19th century";
            Description = " Impressionism, French Impressionism is a major movement, first in painting and later in music. " +
                "The most conspicuous characteristic of Impressionism in painting was an attempt to accurately and objectively " +
                "record visual reality in terms of the transient effects of light and color.";
        }
    }

    public class Abstract : Style
    {
        public Abstract()
        {
            Name = "Abstract art";
            InceptionYear = "The late 19th century";
            Description = "Abstract art is a style that rejects a realistic depiction of reality. The goal of abstract artists " +
                "is to evoke feelings, and emotions in the public. This art is non-figurative and non-objective. " +
                "There are no specific plots, classical, or traditional techniques.";
        }
    }

    public class Surrealism : Style
    {
        public Surrealism()
        {
            Name = "Surrealism";
            InceptionYear = "The late 1910s";
            Description = "Surrealism is a movement in visual art and literature, flourishing in Europe between World Wars I and II. " +
                "Surrealism grew principally out of the earlier Dada movement, which before World War I produced works of anti-art that " +
                "deliberately defied reason; but Surrealism’s emphasis was not on negation but on positive expression.";
        }
    }

    public class Symbolism : Style
    {
        public Symbolism()
        {
            Name = "Symbolism";
            InceptionYear = "The 1880s";
            Description = "Symbolism is an art movement of French and Belgian origin seeking to represent absolute truths symbolically " +
                "through language and metaphorical images, mainly as a reaction against naturalism and realism. Symbolist artists sought " +
                "to express individual emotional experiences through the subtle and suggestive use of highly symbolized language.";
        }
    }

    public class Cubism : Style
    {
        public Cubism()
        {
            Name = "Cubism";
            InceptionYear = "The early 20th century";
            Description = "Cubism is a highly influential visual arts style, which emphasizes the flat, two-dimensional surface of " +
                "the picture plane, rejecting the traditional techniques of perspective, foreshortening, modeling, and chiaroscuro. " +
                "Cubist painters presented a new reality in paintings that depicted radically fragmented objects.";
        }
    }

    public class Futurism : Style
    {
        public Futurism()
        {
            Name = "Futurism";
            InceptionYear = "The early 20th century";
            Description = " Futurism is an artistic movement that emphasizes the dynamism, speed, energy, and power of the machine " +
                "and the vitality, change, and restlessness of modern life. A distinctive feature of this style is the desire to find " +
                "a way to show the dynamics of movement with static means of painting.";
        }
    }
}

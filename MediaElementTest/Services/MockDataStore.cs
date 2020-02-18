using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaElementTest.Models;

namespace MediaElementTest.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Color Converters", Description="Xamarin.Essentials provides developers with cross-platform APIs for their mobile applications. On this week's Xamarin.Essential API of the week we take a look at built in color converters and helper methods simplifying development.", HighQualityURL="https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters_high.mp4", LowQualityURL = "https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters.mp4", MediumQualityURL = "https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters_mid.mp4"  },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Embeded images", Description="Xamarin.Essentials provides developers with cross-platform APIs for their mobile applications. On this week's Xamarin.Essential API of the week we take a look at built in color converters and helper methods simplifying development.", HighQualityURL="https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages_high.mp4", LowQualityURL = "https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages.mp4", MediumQualityURL = "https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages_mid.mp4"  },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Color Converters", Description="Xamarin.Essentials provides developers with cross-platform APIs for their mobile applications. On this week's Xamarin.Essential API of the week we take a look at built in color converters and helper methods simplifying development.", HighQualityURL="https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters_high.mp4", LowQualityURL = "https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters.mp4", MediumQualityURL = "https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters_mid.mp4"  },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Embeded images", Description="Xamarin.Essentials provides developers with cross-platform APIs for their mobile applications. On this week's Xamarin.Essential API of the week we take a look at built in color converters and helper methods simplifying development.", HighQualityURL="https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages_high.mp4", LowQualityURL = "https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages.mp4", MediumQualityURL = "https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages_mid.mp4"  },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Color Converters", Description="Xamarin.Essentials provides developers with cross-platform APIs for their mobile applications. On this week's Xamarin.Essential API of the week we take a look at built in color converters and helper methods simplifying development.", HighQualityURL="https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters_high.mp4", LowQualityURL = "https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters.mp4", MediumQualityURL = "https://sec.ch9.ms/ch9/5a1c/b70989c3-7875-45e5-9181-13523b845a1c/ColorConverters_mid.mp4"  },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Embeded images", Description="Xamarin.Essentials provides developers with cross-platform APIs for their mobile applications. On this week's Xamarin.Essential API of the week we take a look at built in color converters and helper methods simplifying development.", HighQualityURL="https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages_high.mp4", LowQualityURL = "https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages.mp4", MediumQualityURL = "https://sec.ch9.ms/ch9/8f2d/627e9c01-762a-4cdf-88c4-62ffbd748f2d/XamarinForms101UsingEmbeddedImages_mid.mp4"  },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
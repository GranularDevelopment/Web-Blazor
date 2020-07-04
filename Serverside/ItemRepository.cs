﻿using Grpc.Core;
using Models;
using ServiceProtocol;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Serverside
{
    public class ItemRepositoryImpl : ItemRepository.ItemRepositoryBase, IGenericCRUD
    {

        public override Task<ActionResponse> AddNewItem(Item request, ServerCallContext context)
        {
            return this.GenericCreate<Item>(request);
        }

        public override Task<ItemList> GetMatchingItems(Item itemToMatch, ServerCallContext context)
        {
            ItemList i = new ItemList();
            this.GenericWrappedInvoke<Item>( itemToMatch, db => from r in db.Items where r.Name == itemToMatch.Name select r, (x) => i.Items.Add(x) );
            return Task.FromResult(i);
        }
        public override Task<ItemList> GetAllItems(Google.Protobuf.WellKnownTypes.Empty empty, ServerCallContext context)
        {
            ItemList i = new ItemList();
            this.GenericWrappedInvoke<Item>( null, db => from r in db.Items select r, (x) => i.Items.Add(x) );
            return Task.FromResult(i);
        }
    }
}

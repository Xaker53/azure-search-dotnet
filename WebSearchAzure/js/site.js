

//const { SearchIndexClient, SearchClient, AzureKeyCredential, odata } = require("@azure/search-documents");

import {
    SearchClient,
    SearchIndexClient,
    AzureKeyCredential
} from '@azure/search-documents';


const endpoint = 'https://search53.search.windows.net';
const apiKey = "FVSYI2BfI4x26m6LDy55Ix4vaQqxvKlX7SKCxtmJf2AzSeCxpQRV";

async function main() {
    console.log(`Running Azure AI Search Javascript quickstart...`);
    if (!endpoint || !apiKey) {
        console.log("Make sure to set valid values for endpoint and apiKey with proper authorization.");
        return;
    }
}
main();
const indexName = indexDefinition["name"];
const indexClient = new SearchIndexClient(endpoint, apiKey);
console.log("indexClient");
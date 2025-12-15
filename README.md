WorkFlow
==========
1. Source System
   a)Sends an event via webhook to your Azure APIM endpoint.
   b)APIM forwards request to your Middleware API.
2. Azure API Management (APIM)
   a)Webhook endpoint
   b)Security layer
   c)Rate limiting / throttling
   d)Transformation (JSON/XML)
   e)Forwarding to backend middleware APIs
3. Middleware Layer
This can be:
   a)Azure Functions (preferred & used this)
   b)Web API (.NET Core)    (Not validation friendly)
   c)Logic Apps (Not for complex logics.you can use for simple workflows)
It contains:
Fetch logic,Validation logic,Retry/poll mechanism,DB operations,Final push to Destination API
4. Middleware Database
Used to store:
   a)Received data from Source
   b)Validation status
   c)Attempt count & retry state
   d)Final processed records
5. Destination System
Receives final validated payload through APIM.


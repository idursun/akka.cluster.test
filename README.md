# akka.cluster.test

I have two nodes with different roles, one of them being the seed node. I also have a consisten-hash-group, and when i ask for routees, I get one routee, which is expected. I start another instance of the worker node and ask for routees and i still get one routee. Is this normal behaviour? if so, how can i get router to be updated with the new cluster members?

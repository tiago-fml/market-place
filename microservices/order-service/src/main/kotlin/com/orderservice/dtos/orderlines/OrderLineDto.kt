package com.orderservice.dtos.orderlines

import java.util.*

class OrderLineDto(
    val id: UUID,
    val productId: UUID,
    val productDescription: String,
    val quantity:Long,
    val price:Double
)
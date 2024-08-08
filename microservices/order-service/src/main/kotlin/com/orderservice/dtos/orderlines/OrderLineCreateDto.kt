package com.orderservice.dtos.orderlines

import java.util.*

class OrderLineCreateDto(
    val productId: UUID,
    val productDescription: String,
    val quantity:Long,
    val price:Double
)
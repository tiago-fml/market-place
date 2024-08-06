package com.orderservice.dtos

import org.springframework.context.annotation.Description
import java.util.*

class OrderLineCreateDto(
    val productId: UUID,
    val productDescription: String,
    val quantity:Long,
    val price:Double
)
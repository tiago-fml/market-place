package com.orderservice.models

import com.orderservice.dtos.OrderLineCreateDto
import jakarta.persistence.*
import java.util.UUID
import kotlin.reflect.jvm.internal.impl.resolve.scopes.receivers.ThisClassReceiver

@Entity
@Table(name = "orderslines")
class OrderLine (
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id:UUID? = null,
    val productId:UUID,
    val productDescription: String,
    val quantity:Long,
    val price:Double,

    @ManyToOne
    var order: Order? = null
){
    // Map from DTO to entity
    companion object {
        fun fromCreateDto(dto: OrderLineCreateDto): OrderLine {
            return OrderLine(
                productId = dto.productId,
                productDescription = dto.productDescription,
                quantity = dto.quantity,
                price = dto.price,
                order = null
            )
        }
    }
}